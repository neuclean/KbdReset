/*
 * Copyright 2026 neuclean@proton.me
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.Runtime.InteropServices;

namespace KbdReset
{
    internal static class Program
    {
        private const uint KEYEVENTF_KEYUP = 0x0002;
        private const uint MB_ICONINFORMATION = 0x00000040;

        [DllImport("user32.dll")]
        private static extern void keybd_event(
            byte bVk,
            byte bScan,
            uint dwFlags,
            UIntPtr dwExtraInfo);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int MessageBox(
            IntPtr hWnd,
            string lpText,
            string lpCaption,
            uint uType);

        [STAThread]
        private static void Main()
        {
            for (int virtualKey = 0; virtualKey <= 255; virtualKey++)
            {
                keybd_event(
                    (byte)virtualKey,
                    0,
                    KEYEVENTF_KEYUP,
                    UIntPtr.Zero);
            }

            MessageBox(
                IntPtr.Zero,
                "The keyboard has been reset.",
                "kbdreset",
                MB_ICONINFORMATION);
        }
    }
}
