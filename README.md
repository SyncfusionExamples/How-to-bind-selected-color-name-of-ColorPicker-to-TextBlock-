How to bind selected color name of ColorPicker to TextBlock?

In ColorPicker control, the Selected color’s name can be displayed by binding the color name in TextBlock. The color name from color code can get using SuchColor() method.
MainWindow.xaml:
<Window x:Class="colorpicker.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusion="http://schemas.syncfusion.com/wpf"
        xmlns:local="clr-namespace:colorpicker"
        Title="MainWindow">
    <Window.Resources>
        <local:ColorHexToStringConverter x:Key="ColorToWordKnownColors">
        </local:ColorHexToStringConverter>
    </Window.Resources>
    <Window.DataContext>
        <local:ViewModel/>
    </Window.DataContext>
    <Grid>
        <Canvas>
            <syncfusion:ColorPicker HorizontalAlignment="Center" 
                                    VerticalAlignment="Center" Color="{Binding  
                                    Colorprop,Mode=TwoWay}" Canvas.Top="100"  
                                    Canvas.Left="300">
            </syncfusion:ColorPicker>

            <TextBlock Text="{ Binding  Colorprop, Converter={StaticResource  
                              ColorToWordKnownColors}}" HorizontalAlignment="Center" 
                              VerticalAlignment="Center" Canvas.Top="105"  
                              Canvas.Left="450"/>
        </Canvas>
    </Grid>
</Window>

View Model.cs
    public class ViewModel : INotifyPropertyChanged
    {
        private Color _color = Colors.Green;
        public Color Colorprop
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                OnPropertyChanged("Colorprop");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
    }

MainWindow.cs
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    public class ColorHexToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, 
                               System.Globalization.CultureInfo culture)
        {
            Color color = (Color)value;
            string _Color= ColorEdit.SuchColor(color)[0];
            return _Color;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                   System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }




