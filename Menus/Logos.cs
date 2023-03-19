using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Colorful;
using Console = Colorful.Console;

namespace InventoryAppV2
{
    internal class Logos
    {
        public static void TitleLogo()
        {
            string titleLogo = @"
  _________                     .__                 ___________                             .___   _____    _________
 /   _____/____    _____ ______ |  |   ____ ___.__. \_   _____/____ _______  _____   ______ |   | /     \  /   _____/
 \_____  \\__  \  /     \\____ \|  | _/ __ <   |  |  |    __) \__  \\_  __ \/     \ /  ___/ |   |/  \ /  \ \_____  \ 
 /        \/ __ \|  Y Y  \  |_> >  |_\  ___/\___  |  |     \   / __ \|  | \/  Y Y  \\___ \  |   /    Y    \/        \
/_______  (____  /__|_|  /   __/|____/\___  > ____|  \___  /  (____  /__|  |__|_|  /____  > |___\____|__  /_______  /
        \/     \/      \/|__|             \/\/           \/        \/            \/     \/              \/        \/ 
";

            Console.WriteLine(titleLogo, Color.LimeGreen);
        }

        public static void AddLogo()
        {

        }

        public static void EditLogo()
        {
            string editLogo = @"
o   o                   o-o                       o   o         o   o     
|   |                  |                          |\ /|         |\  |     
o   o o-o o-o o  o      o-o  o-o o-o o-o o  o     | O | o-o     | \ | o-o 
 \ /  |-' |   |  |         | | | |   |   |  |     |   | |-'     |  \| | | 
  o   o-o o   o--O     o--o  o-o o   o   o--O     o   o o-o     o   o o-o 
                 |                          |                             
              o--o                       o--o                            


o       o         o  o     o--o         o     o      o   o               | 
|       |         | /      |   | o      |     |      |\  |               | 
o   o   o o-o o-o OO       O-Oo    o--o O--o -o-     | \ | o-o o   o   o | 
 \ / \ /  | | |   | \      |  \  | |  | |  |  |      |  \| | |  \ / \ /   
  o   o   o-o o   o  o     o   o | o--O o  o  o      o   o o-o   o   o   O 
                                      |                                   
                                   o--o                                   
";

            Console.WriteLine(editLogo, Color.BlanchedAlmond);
        }
    }
}
