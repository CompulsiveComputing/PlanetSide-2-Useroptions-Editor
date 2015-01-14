using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PS2_INI_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    	
    	private string _applicationName = "PlanetSide 2 Useroptions Editor";
		private string _applicationShortName = "PS2 INI Editer";
		private string _versionString = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
		
		//private int _defaultIncrimentalBackupsToKeep = 10;
		//private string _userOptionsLocation = "";
		//private string _backupFolderLocation = "";
		//private string _valueCatalogueLocation = "";
		//private int _incrimentalBackupsToKeep;
		
		//private string _activeFileName = "";
		
		private static string _currentWorkDirectory = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
		private static string _currentRootDirectory = Directory.GetDirectoryRoot(_currentWorkDirectory).ToString();
		private string _valueCatalogueName = "ps2useroptionscatalogue.xml";
		
		private UserOptionsINI _currentUserOptionsINI;
		
		private List<UserOptionsINI> _backupINIlist = new List<UserOptionsINI>();
		
		private string _activeSection = "",_activeValue = "";
		int _activeSectionNumber = -1, _activeValueNumber = -1;		
		
		private string[] _defaultGamePaths =
		{
			"Program Files (x86)\\Steam\\steamapps\\common\\PlanetSide 2\\",
			"Program Files\\Steam\\steamapps\\common\\PlanetSide 2\\",
			"Program Files (x86)\\PlanetSide 2\\",
			"Users\\Public\\Sony Online Entertainment\\Installed Games\\PlanetSide 2\\",
			"Planetside 2\\"
		};
		
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
