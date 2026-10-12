namespace Bai1
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            if (args.Length > 0 && args[0] == "--capture")
            {
                try
                {
                    File.WriteAllText("capture.log", "Bắt đầu capture...\n");
                    TestCapture.ChayTuDong();
                    File.AppendAllText("capture.log", "Hoàn tất capture!\n");
                }
                catch (Exception ex)
                {
                    File.AppendAllText("capture.log", "Lỗi: " + ex.ToString() + "\n");
                }
                return;
            }

            Application.Run(new Form1());
        }
    }
}