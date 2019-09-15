using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace USB_Multi_Copy
{
    public partial class MainWindow : Window
    {
        private Dictionary<String, Boolean> driveLetters = new Dictionary<string, bool>();
        private String filesystemString = "EXFAT";
        private String labelString;

        public MainWindow()
        {
            InitializeComponent();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Check_Values_In_CheckBoxes();

            if (driveLetters.Count == 0)
            {
                System.Windows.MessageBox.Show("No drives selected", "Abort");
                return;
            }
            if (drive_name == null || drive_name.Equals(""))
            {
                System.Windows.MessageBox.Show("Drive label is missing", "Abort");
                return;
            }

            if (folder_path == null || !Directory.Exists(folder_path.Text))
            {
                System.Windows.MessageBox.Show("Source folder is not assigned or does not exist", "Abort");
                return;
            }

            int ret = IsLabelValid();
            if (ret != 0)
            {
                switch (ret)
                {
                    case 1:
                        System.Windows.MessageBox.Show("Drive label to long (<=11)", "Abort");
                        break;
                    case 2:
                        System.Windows.MessageBox.Show("Drive label to long (<=32)", "Abort");
                        break;
                    case 3:
                        System.Windows.MessageBox.Show("Drive label contains illegal characters", "Abort");
                        break;
                }
                return;
            }

            String message = "Make sure no valuable data is on selected drives: \n";
            foreach (KeyValuePair<String, Boolean> dl in driveLetters)
            {
                message += "Drive " + dl.Key + ":\n";
            }
            MessageBoxResult result = System.Windows.MessageBox.Show(message, "Before we start", MessageBoxButton.OKCancel);
            switch (result)
            {
                case MessageBoxResult.OK:
                    Logic logic = new Logic();
                    logic.Start(driveLetters, labelString, filesystemString, folder_path.Text);
                    break;
                case MessageBoxResult.Cancel:
                    return;
            }
        }

        private int IsLabelValid()
        {
            switch (filesystemString)
            {
                case "EXFAT":
                case "FAT32":
                    if (drive_name.Text.Length > 11)
                    {
                        return 1;
                    }
                    break;
                case "NTFS":
                    if (drive_name.Text.Length > 32)
                    {
                        return 2;
                    }
                    break;
            }

            String[] InvalidChars = { "<", ">", ":", "\"", "/", "\\", "|", "?", "*" };
            foreach (String c in InvalidChars)
            {
                if (drive_name.Text.Contains(c))
                {
                    return 3;
                }
            }

            return 0;
        }

        private void Check_Values_In_CheckBoxes()
        {
            driveLetters.Clear();
            if (cb_a.IsChecked == true)
            {
                driveLetters.Add("A", true);
            }
            if (cb_b.IsChecked == true)
            {
                driveLetters.Add("B", true);
            }
            if (cb_c.IsChecked == true)
            {
                driveLetters.Add("C", true);
            }
            if (cb_d.IsChecked == true)
            {
                driveLetters.Add("D", true);
            }
            if (cb_e.IsChecked == true)
            {
                driveLetters.Add("E", true);
            }
            if (cb_f.IsChecked == true)
            {
                driveLetters.Add("F", true);
            }
            if (cb_g.IsChecked == true)
            {
                driveLetters.Add("G", true);
            }
            if (cb_h.IsChecked == true)
            {
                driveLetters.Add("H", true);
            }
            if (cb_i.IsChecked == true)
            {
                driveLetters.Add("I", true);
            }
            if (cb_j.IsChecked == true)
            {
                driveLetters.Add("J", true);
            }
            if (cb_k.IsChecked == true)
            {
                driveLetters.Add("K", true);
            }
            if (cb_l.IsChecked == true)
            {
                driveLetters.Add("L", true);
            }
            if (cb_m.IsChecked == true)
            {
                driveLetters.Add("M", true);
            }
            if (cb_n.IsChecked == true)
            {
                driveLetters.Add("N", true);
            }
            if (cb_o.IsChecked == true)
            {
                driveLetters.Add("O", true);
            }
            if (cb_p.IsChecked == true)
            {
                driveLetters.Add("P", true);
            }
            if (cb_q.IsChecked == true)
            {
                driveLetters.Add("Q", true);
            }
            if (cb_r.IsChecked == true)
            {
                driveLetters.Add("R", true);
            }
            if (cb_s.IsChecked == true)
            {
                driveLetters.Add("S", true);
            }
            if (cb_t.IsChecked == true)
            {
                driveLetters.Add("T", true);
            }
            if (cb_u.IsChecked == true)
            {
                driveLetters.Add("U", true);
            }
            if (cb_v.IsChecked == true)
            {
                driveLetters.Add("V", true);
            }
            if (cb_w.IsChecked == true)
            {
                driveLetters.Add("W", true);
            }
            if (cb_x.IsChecked == true)
            {
                driveLetters.Add("X", true);
            }
            if (cb_y.IsChecked == true)
            {
                driveLetters.Add("Y", true);
            }
            if (cb_z.IsChecked == true)
            {
                driveLetters.Add("Z", true);
            }
        }

        private void Cb_a_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["A"] = (cb_a.IsChecked == true);
        }

        private void Cb_b_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["B"] = (cb_b.IsChecked == true);
        }

        private void Cb_c_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["C"] = (cb_c.IsChecked == true);
        }

        private void Cb_d_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["D"] = (cb_d.IsChecked == true);
        }

        private void Cb_e_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["E"] = (cb_e.IsChecked == true);
        }

        private void Cb_f_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["F"] = (cb_f.IsChecked == true);
        }

        private void Cb_g_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["G"] = (cb_g.IsChecked == true);
        }

        private void Cb_h_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["H"] = (cb_h.IsChecked == true);
        }

        private void Cb_i_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["I"] = (cb_i.IsChecked == true);
        }

        private void Cb_j_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["J"] = (cb_j.IsChecked == true);
        }

        private void Cb_k_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["K"] = (cb_k.IsChecked == true);
        }

        private void Cb_l_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["L"] = (cb_l.IsChecked == true);
        }

        private void Cb_m_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["M"] = (cb_m.IsChecked == true);
        }

        private void Cb_n_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["N"] = (cb_n.IsChecked == true);
        }

        private void Cb_o_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["O"] = (cb_o.IsChecked == true);
        }

        private void Cb_p_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["P"] = (cb_p.IsChecked == true);
        }

        private void Cb_q_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["Q"] = (cb_q.IsChecked == true);
        }

        private void Cb_r_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["R"] = (cb_r.IsChecked == true);
        }

        private void Cb_s_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["S"] = (cb_s.IsChecked == true);
        }

        private void Cb_t_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["T"] = (cb_t.IsChecked == true);
        }

        private void Cb_u_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["U"] = (cb_u.IsChecked == true);
        }

        private void Cb_v_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["V"] = (cb_v.IsChecked == true);
        }

        private void Cb_w_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["W"] = (cb_w.IsChecked == true);
        }

        private void Cb_x_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["X"] = (cb_x.IsChecked == true);
        }

        private void Cb_y_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["Y"] = (cb_y.IsChecked == true);
        }

        private void Cb_z_Checked(object sender, RoutedEventArgs e)
        {
            driveLetters["Z"] = (cb_z.IsChecked == true);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(filesystem.SelectedItem.ToString().Split(' '));

            ComboBoxItem cbi = (ComboBoxItem)filesystem.SelectedItem;
            if (cbi.Content != null)
            {
                filesystemString = cbi.Content.ToString();
            }
        }

        private void Drive_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            labelString = drive_name.Text;
        }

        private void BrowseFolder(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = false;
            folderDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
            System.Windows.Forms.DialogResult result = folderDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                String sPath = folderDialog.SelectedPath;
                folder_path.Text = sPath;
            }
        }
    }
}