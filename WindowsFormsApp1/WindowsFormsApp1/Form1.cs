﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var s = new StringBuilder();
            s.AppendLine("I8, A,001");
            s.AppendLine();
            s.AppendLine();

            s.AppendLine("Q272,024");
 s.AppendLine("q831");
            s.AppendLine("rN");
            s.AppendLine("S4");
            s.AppendLine("D10");
            s.AppendLine("ZT");
            s.AppendLine("JF");
            s.AppendLine("OD");
            s.AppendLine("R160,0");
            s.AppendLine("f100");
            s.AppendLine("N");
            s.AppendLine("B95,81,0,1,3,9,78,B,\"1234567890\"");
            s.AppendLine("P1");

            // Allow the user to select a printer.
            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            if (DialogResult.OK == pd.ShowDialog(this))
            {
                // Send a printer-specific to the printer.
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, s.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Allow the user to select a file.
            OpenFileDialog ofd = new OpenFileDialog();
            if (DialogResult.OK == ofd.ShowDialog(this))
            {
                // Allow the user to select a printer.
                PrintDialog pd = new PrintDialog();
                pd.PrinterSettings = new PrinterSettings();
                if (DialogResult.OK == pd.ShowDialog(this))
                {
                    // Print the file to the printer.
                    RawPrinterHelper.SendFileToPrinter(pd.PrinterSettings.PrinterName, ofd.FileName);
                }
            }
        }
    }
}



public class RawPrinterHelper
{
    // Structure and API declarions:
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class DOCINFOA
    {
        [MarshalAs(UnmanagedType.LPStr)] public string pDocName;
        [MarshalAs(UnmanagedType.LPStr)] public string pOutputFile;
        [MarshalAs(UnmanagedType.LPStr)] public string pDataType;
    }
    [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

    [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool ClosePrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

    [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool EndDocPrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool StartPagePrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool EndPagePrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

    // SendBytesToPrinter()
    // When the function is given a printer name and an unmanaged array
    // of bytes, the function sends those bytes to the print queue.
    // Returns true on success, false on failure.
    public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
    {


        Int32 dwError = 0, dwWritten = 0;
        IntPtr hPrinter = new IntPtr(0);
        DOCINFOA di = new DOCINFOA();
        bool bSuccess = false; // Assume failure unless you specifically succeed.

        di.pDocName = "My C#.NET RAW Document";
        di.pDataType = "RAW";

        // Open the printer.
        if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
        {
            // Start a document.
            if (StartDocPrinter(hPrinter, 1, di))
            {
                // Start a page.
                if (StartPagePrinter(hPrinter))
                {
                    // Write your bytes.
                    bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                    EndPagePrinter(hPrinter);
                }
                EndDocPrinter(hPrinter);
            }
            ClosePrinter(hPrinter);
        }
        // If you did not succeed, GetLastError may give more information
        // about why not.
        if (bSuccess == false)
        {
            dwError = Marshal.GetLastWin32Error();
        }
        return bSuccess;
    }

    public static bool SendFileToPrinter(string szPrinterName, string szFileName)
    {
        // Open the file.
        FileStream fs = new FileStream(szFileName, FileMode.Open);
        // Create a BinaryReader on the file.
        BinaryReader br = new BinaryReader(fs);
        // Dim an array of bytes big enough to hold the file's contents.
        Byte[] bytes = new Byte[fs.Length];
        bool bSuccess = false;
        // Your unmanaged pointer.
        IntPtr pUnmanagedBytes = new IntPtr(0);
        int nLength;

        nLength = Convert.ToInt32(fs.Length);
        // Read the contents of the file into the array.
        bytes = br.ReadBytes(nLength);
        // Allocate some unmanaged memory for those bytes.
        pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
        // Copy the managed byte array into the unmanaged array.
        Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
        // Send the unmanaged bytes to the printer.
        bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
        // Free the unmanaged memory that you allocated earlier.
        Marshal.FreeCoTaskMem(pUnmanagedBytes);
        return bSuccess;
    }
    public static bool SendStringToPrinter(string szPrinterName, string szString)
    {
        IntPtr pBytes;
        Int32 dwCount;
        // How many characters are in the string?
        dwCount = szString.Length;
        // Assume that the printer is expecting ANSI text, and then convert
        // the string to ANSI text.
        pBytes = Marshal.StringToCoTaskMemAnsi(szString);
        // Send the converted ANSI string to the printer.
        SendBytesToPrinter(szPrinterName, pBytes, dwCount);
        Marshal.FreeCoTaskMem(pBytes);
        return true;
    }

    public static bool SendFileToPrinter2(string szPrinterName, string szFileName)
    {
        // Open the file.
        MemoryStream fs = new MemoryStream(System.Text.Encoding.ASCII.GetBytes(szFileName));
        // Create a BinaryReader on the file.
        BinaryReader br = new BinaryReader(fs);
        // Dim an array of bytes big enough to hold the file's contents.
        Byte[] bytes = new Byte[fs.Length];
        bool bSuccess = false;
        // Your unmanaged pointer.
        IntPtr pUnmanagedBytes = new IntPtr(0);
        int nLength;

        nLength = Convert.ToInt32(fs.Length);
        // Read the contents of the file into the array.
        bytes = br.ReadBytes(nLength);
        // Allocate some unmanaged memory for those bytes.
        pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
        // Copy the managed byte array into the unmanaged array.
        Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
        // Send the unmanaged bytes to the printer.
        bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
        // Free the unmanaged memory that you allocated earlier.
        Marshal.FreeCoTaskMem(pUnmanagedBytes);
        return bSuccess;
    }
}