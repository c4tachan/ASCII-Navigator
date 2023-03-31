using ASCII_Navigator;

namespace ASCIINavigator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get desired size of console
            //var values = GetConsoleSize();

            ConsoleDrawer cd = new ConsoleDrawer();

            cd.FillConsole('A');

            // Start the loop that will keep the image displaying
            cd.ListenToConsole();
            
        }

        static (int Width, int Height) GetConsoleSize()
        {
            int width = 20;
            int height = 5;

            return (width, height);
        }
    }
}