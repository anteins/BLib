using System;
using System.Runtime.InteropServices;

public class BLib_DLL
{
    [DllImport("xlua", CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_blib(IntPtr L);

    [DllImport("xlua", CallingConvention = CallingConvention.Cdecl)]
    public static extern void blib_new(IntPtr L, int init_size, int buf_id);

    [DllImport("xlua", CallingConvention = CallingConvention.Cdecl)]
    public static extern void blib_free(IntPtr L, int buf_id);

    [DllImport("xlua", CallingConvention = CallingConvention.Cdecl)]
    public static extern void blib_reset(IntPtr L, int buf_id);

    [DllImport("xlua", CallingConvention = CallingConvention.Cdecl)]
    public static extern int blib_set_channel(IntPtr L, IntPtr buf, int buf_id);

    [DllImport("xlua", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr blib_get_channel(IntPtr L, int buf_id);

    [DllImport("xlua", CallingConvention = CallingConvention.Cdecl)]
    public static extern void blib_write_int(IntPtr buf, int value);

    [DllImport("xlua", CallingConvention = CallingConvention.Cdecl)]
    public static extern void blib_write_string(IntPtr bufL, [MarshalAs(UnmanagedType.LPStr)]string value);

    [DllImport("xlua", CallingConvention = CallingConvention.Cdecl)]
    public static extern void blib_write_short(IntPtr buf, short value);

    [DllImport("xlua", CallingConvention = CallingConvention.Cdecl)]
    public static extern void blib_write_float(IntPtr bufL, float value);

    [DllImport("xlua", CallingConvention = CallingConvention.Cdecl)]
    public static extern void blib_write_double(IntPtr buf, double value);

    [DllImport("xlua", CallingConvention = CallingConvention.Cdecl)]
    public static extern void blib_write_bool(IntPtr buf, bool value);

    [DllImport("xlua", CallingConvention = CallingConvention.Cdecl)]
    public static extern int blib_read_int(IntPtr bufL);

    [DllImport("xlua", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr blib_read_string(IntPtr buf);

    [DllImport("xlua", CallingConvention = CallingConvention.Cdecl)]
    public static extern short blib_read_short(IntPtr buf);

    [DllImport("xlua", CallingConvention = CallingConvention.Cdecl)]
    public static extern float blib_read_float(IntPtr buf);

    [DllImport("xlua", CallingConvention = CallingConvention.Cdecl)]
    public static extern double blib_read_double(IntPtr buf);

    [DllImport("xlua", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool blib_read_bool(IntPtr buf);

    [DllImport("xlua", CallingConvention = CallingConvention.Cdecl)]
    public static extern void set_display_log(LogCallBack logCallBack);

    public delegate void LogCallBack(string logInfo);
    private static LogCallBack cLog = null;
   
    public static void InitCLog()
    {
        cLog = new LogCallBack((string c_log) =>
        {
            string info = DateTime.Now.ToString("[HH:mm:ss]  ") + c_log + "\r\n";
            UnityEngine.Debug.Log(info);
        });
        set_display_log(cLog);
    }

}

