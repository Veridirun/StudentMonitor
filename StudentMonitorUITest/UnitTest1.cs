using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.VisualTree;
using static System.Net.Mime.MediaTypeNames;

namespace StudentMonitorUITest
{
    public class UnitTest1
    {
        [Fact]
        public async void AverageNumber_1_After_Remove()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var listBox = mainWindow.GetVisualDescendants().OfType<ListBox>().First();
            listBox.SelectedIndex = 1;

            var button = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "RemoveStudent");
            button.Command.Execute(button.CommandParameter);

            await Task.Delay(100);

            var textBox = mainWindow.GetVisualDescendants().OfType<TextBlock>().First(b => b.Name == "Average1");
            string text = textBox.Text;

            Assert.Equal("1", text);
        }
        [Fact]
        public async void AverageNumber_05_After_Remove()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var listBox = mainWindow.GetVisualDescendants().OfType<ListBox>().First();
            listBox.SelectedIndex = 0;

            var button = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "RemoveStudent");
            button.Command.Execute(button.CommandParameter);

            await Task.Delay(100);

            var textBox = mainWindow.GetVisualDescendants().OfType<TextBlock>().First(b => b.Name == "Average0");
            string text = textBox.Text;

            Assert.Equal("0,5", text);
        }
        [Fact]
        public async void AverageNumber_Assert_After_Remove()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);


            var listBoxList = mainWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();
            var buttonRemove = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "RemoveStudent");
            buttonRemove.Command.Execute(buttonRemove.CommandParameter);

            var textBox = mainWindow.GetVisualDescendants().OfType<TextBlock>().First(b => b.Name == "Average1");
            string text = textBox.Text;

            Color c;
            if (Convert.ToDouble(text) < 1) c = Colors.Red;
            else
            if (Convert.ToDouble(text) < 1.5) c = Colors.Yellow;
            else
                c = Colors.Green;
            Color assertColor = (textBox.Background as SolidColorBrush).Color;
            Assert.Equal(c, assertColor);
        }

        [Fact]
        public async void AverageNumber_Yellow1()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var textBox = mainWindow.GetVisualDescendants().OfType<TextBlock>().First(b => b.Name == "Average4");
            string text = textBox.Text;

            Color c;
            if (Convert.ToDouble(text) < 1) c = Colors.Red;
            else
            if (Convert.ToDouble(text) < 1.5) c = Colors.Yellow;
            else
                c = Colors.Green;
            Color assertColor = (textBox.Background as SolidColorBrush).Color;
            Assert.Equal(c, assertColor);
        }
        [Fact]
        public async void ListBoxColor_First_Green1()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var listBoxList = mainWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();

            
            var listBox = listBoxList.ToArray()[0];
            var listBoxText = listBox.GetVisualDescendants().OfType<TextBlock>().First(x => (x.Name != null) && x.Name.Equals("Subject0"));
            var text = listBoxText.Text;
            Color c; 
            switch(text)
            {
                case "0": 
                    c = Colors.Red;
                    break;
                case "1":
                    c = Colors.Yellow;
                    break;
                case "2":
                    c = Colors.Green;
                    break;
                default:
                    c = Colors.White;
                    break;
            };
            Color assertColor = Colors.Green;
            Assert.Equal(c, assertColor);
        }
    }
}