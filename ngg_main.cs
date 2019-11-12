using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ngg
{
    public partial class NGG : Form
    {

        public NGG()
        {
            InitializeComponent();
        }

        //sgsn nri to mme code
        private string nri_to_mmecode(int nri, int nrilength)
        {
            //mmecode = nri *2^(8 - nri length)
            int mmecode = nri * Convert.ToInt32(System.Math.Pow(2, (8 - nrilength)));
            return mmecode.ToString();
        }

        //mme code to sgsn nri
        private string mmecode_to_nri(int mmecode, int nrilength)
        {
            //convert to binary of mmecode
            string bin_mmecode = Convert.ToString(mmecode, 2);

            //bin_mmecode should be 8 bits
            while (bin_mmecode.Length < 8)
            {
                bin_mmecode = "0" + bin_mmecode;
            }

            //get the nri bits from the bin of mmecode and convert to decimalism
            int nri = Convert.ToInt32(bin_mmecode.Substring(0, nrilength), 2);

            return nri.ToString();
        }

        //mme group id to amf region id
        private string mmegid_to_amfregionid(int mmegid)
        {
            //convert to binary of mme group id
            string bin_mmegid = Convert.ToString(mmegid, 2);

            //bin of mme gid length to be 16 bits
            while (bin_mmegid.Length < 16)
            {
                bin_mmegid = "0" + bin_mmegid;
            }

            //get the amf region id from the bin of mmegid and convert to decimalism
            int amfregionid = Convert.ToInt32(bin_mmegid.Substring(0, 8), 2);

            return amfregionid.ToString();

        }

        //mme group id + mme code to amf set id
        private string mmegid_mmec_to_amfsetid(int mmegid, int mmec)
        {
            //convert the mmegid to binary
            string bin_mmegid = Convert.ToString(mmegid, 2);

            //bin of mmegid should be 16 bits
            while (bin_mmegid.Length < 16)
            {
                bin_mmegid = "0" + bin_mmegid;
            }

            //convert the mmecode to binary
            string bin_mmec = Convert.ToString(mmec, 2);

            //bin of mmecode should be 8 bits
            while (bin_mmec.Length < 8)
            {
                bin_mmec = "0" + bin_mmec;
            }

            //amfsetid(10 bits)=lowest 8 bits of mmegid + highest 2 bits of mmecode
            string bin_amfsetid = bin_mmegid.Substring(16 - 8) + bin_mmec.Substring(0, 2);

            //convert to decimalism
            int amfsetid = Convert.ToInt32(bin_amfsetid, 2);

            return amfsetid.ToString();

        }

        //mme code to amf pointer 
        private string mmecode_to_amfpointer(int mmec)
        {
            //convert mmecode to binary
            string bin_mmec = Convert.ToString(mmec, 2);

            //bin of mmecode should be 8 bits
            while (bin_mmec.Length < 8)
            {
                bin_mmec = "0" + bin_mmec;
            }

            //amf pointer(6 bits) = the lowest 6 bits of mmecode which totally has 8 bits, then convert to decimalism
            int amfpointer = Convert.ToInt32(bin_mmec.Substring(8 - 6), 2);

            return amfpointer.ToString();

        }

        //amf region id + amf set id to mme group id
        private string ari_asi_to_mmegid(int amfregionid, int amfsetid)
        {
            //convert amf region id to binary
            string bin_amfregionid = Convert.ToString(amfregionid, 2);

            //convert amf set id to binary
            string bin_amfsetid = Convert.ToString(amfsetid, 2);

            //bin of amf region id is 8 bits
            while (bin_amfregionid.Length < 8)
            {
                bin_amfregionid = "0" + bin_amfregionid;
            }

            //bin of amf set id is 10 bits
            while (bin_amfsetid.Length < 10)
            {
                bin_amfsetid = "0" + bin_amfsetid;
            }

            //mme group id(16bits) = amf region id(8 bits) + the highest 8 bits of amf set id
            string bin_mmegid = bin_amfregionid + bin_amfsetid.Substring(0, 8);

            //convert the binary of mmegid to decimalism
            int mmegid = Convert.ToInt32(bin_mmegid, 2);

            return mmegid.ToString();
        }

        //amf set id + amf pointer to mme code
        private string asi_ap_to_mmecode(int amfsetid, int amfpointer)
        {
            //convert amf set id to binary
            string bin_amfsetid = Convert.ToString(amfsetid, 2);

            //convert amf pointer to binary
            string bin_amfpointer = Convert.ToString(amfpointer, 2);

            //bin of amf set id is 10 bits
            while (bin_amfsetid.Length < 10)
            {
                bin_amfsetid = "0" + bin_amfsetid;
            }

            //bin of amf pointer is 6 bits
            while (bin_amfpointer.Length < 6)
            {
                bin_amfpointer = "0" + bin_amfpointer;
            }

            //mmecode(8 bits)=lowest 2 bits of amf set id + total 6 bits of amf pointer
            string bin_mmecode = bin_amfsetid.Substring(10 - 2) + bin_amfpointer;

            //convert the bin of mmecode to decimalism
            int mmecode = Convert.ToInt32(bin_mmecode, 2);

            return mmecode.ToString();

        }

        //MMECode + Nrilength to NRI
        private void mmecode_nrilength_to_nri(string mmecode, string nrilength)
        {
            if (nrilength != "" && nrilength == "4" && (Regex.IsMatch(mmecode, "^([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-3][0-9]|240)$")))
            {
                textBox_nri.Text = mmecode_to_nri(Convert.ToInt32(mmecode), Convert.ToInt32(nrilength));
                textBox_nri_hex.Text = hex_two(textBox_nri.Text);
            }
            else if (nrilength != "" && nrilength == "5" && (Regex.IsMatch(mmecode, "^([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-3][0-9]|24[0-8])$")))
            {
                textBox_nri.Text = mmecode_to_nri(Convert.ToInt32(mmecode), Convert.ToInt32(nrilength));
                textBox_nri_hex.Text = hex_two(textBox_nri.Text);
            }
            else if (nrilength != "" && nrilength == "6" && (Regex.IsMatch(mmecode, "^([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-2])$")))
            {
                textBox_nri.Text = mmecode_to_nri(Convert.ToInt32(mmecode), Convert.ToInt32(nrilength));
                textBox_nri_hex.Text = hex_two(textBox_nri.Text);
            }
            else if (nrilength != "" && nrilength == "7" && (Regex.IsMatch(mmecode, "^([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-4])$")))
            {
                textBox_nri.Text = mmecode_to_nri(Convert.ToInt32(mmecode), Convert.ToInt32(nrilength));
                textBox_nri_hex.Text = hex_two(textBox_nri.Text);
            }
            else if (nrilength != "" && nrilength == "8" && (Regex.IsMatch(mmecode, "^([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$")))
            {
                textBox_nri.Text = mmecode_to_nri(Convert.ToInt32(mmecode), Convert.ToInt32(nrilength));
                textBox_nri_hex.Text = hex_two(textBox_nri.Text);
            }
            else
            {
                textBox_alarm.Text += "NRI and MMEcode is not mateched.";
            }
        }

        private string hex_two(string dec)
        {
            string hex_two = Convert.ToInt32(dec).ToString("X");
            while (hex_two.Length < 2)
            {
                hex_two = "0" + hex_two;
            }
            return hex_two;
        }

        private string hex_three(string dec)
        {
            string hex_three = Convert.ToInt32(dec).ToString("X");
            while (hex_three.Length < 3)
            {
                hex_three = "0" + hex_three;
            }
            return hex_three;
        }

        private string hex_four(string dec)
        {
            string hex_four = Convert.ToInt32(dec).ToString("X");
            while (hex_four.Length < 4)
            {
                hex_four = "0" + hex_four;
            }
            return hex_four;
        }

        private void alarm_yes()
        {
            textBox_alarm.ForeColor = Color.Green;
            textBox_alarm.Text = "      ##                    ##      " + System.Environment.NewLine + "         ##              ##         " + System.Environment.NewLine + "            ##        ##            " + System.Environment.NewLine + "               ##  ##               " + System.Environment.NewLine + "                  ##                  " + System.Environment.NewLine + "                  ##                  " + System.Environment.NewLine + "                  ##                  " + System.Environment.NewLine + "                  ##                  " + System.Environment.NewLine + "                  ##                  " + System.Environment.NewLine + "                  ##                  ";
        }

        //nri textbox can trigger this action
        private void textBox_nri_KeyUp(object sender, KeyEventArgs e)
        {
            //clear the alarm textbox
            textBox_alarm.Text = "";
            textBox_alarm.ForeColor = Color.Red;

            if (textBox_nri.Text == "")
            {
                textBox_alarm.Text = "NRI cannot be empty!";
            }
            else
            {
                if (textBox_nl.Text != "" && textBox_nl.Text == "4")
                {
                    if (Regex.IsMatch(textBox_nri.Text, "^([0-9]|(1[0-5]))$"))
                    {
                        textBox_nri_hex.Text = hex_two(textBox_nri.Text);

                        textBox_mc.Text = nri_to_mmecode(Convert.ToInt32(textBox_nri.Text), Convert.ToInt32(textBox_nl.Text));
                        textBox_mc_hex.Text = hex_two(textBox_mc.Text);

                        textBox_ap.Text = mmecode_to_amfpointer(Convert.ToInt32(textBox_mc.Text));
                        textBox_ap_hex.Text = hex_two(textBox_ap.Text);

                        if (textBox_mgi.Text != "" && (Regex.IsMatch(textBox_mgi.Text, "^([1-9]|[1-9][0-9]|[1-9][0-9]{2}|[1-9][0-9]{3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-3,5])$")))
                        {
                            textBox_mgi_hex.Text = hex_four(textBox_mgi.Text);
                            textBox_ari.Text = mmegid_to_amfregionid(Convert.ToInt32(textBox_mgi.Text));
                            textBox_asi.Text = mmegid_mmec_to_amfsetid(Convert.ToInt32(textBox_mgi.Text), Convert.ToInt32(textBox_mc.Text));

                            textBox_ari_hex.Text = hex_two(textBox_ari.Text);
                            textBox_asi_hex.Text = hex_three(textBox_asi.Text);
                        }


                        alarm_yes();
                    }
                    else
                    {
                        textBox_alarm.Text = "If NRI Length is 4, NRI is from 0 to 15.";
                    }
                }
                else if (textBox_nl.Text != "" && textBox_nl.Text == "5")
                {
                    if (Regex.IsMatch(textBox_nri.Text, "^([0-9]|([1-2][0-9])|(3[0-1]))$"))
                    {
                        textBox_nri_hex.Text = hex_two(textBox_nri.Text);

                        textBox_mc.Text = nri_to_mmecode(Convert.ToInt32(textBox_nri.Text), Convert.ToInt32(textBox_nl.Text));
                        textBox_mc_hex.Text = hex_two(textBox_mc.Text);

                        textBox_ap.Text = mmecode_to_amfpointer(Convert.ToInt32(textBox_mc.Text));
                        textBox_ap_hex.Text = hex_two(textBox_ap.Text);

                        if (textBox_mgi.Text != "" && (Regex.IsMatch(textBox_mgi.Text, "^([1-9]|[1-9][0-9]|[1-9][0-9]{2}|[1-9][0-9]{3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-3,5])$")))
                        {
                            textBox_mgi_hex.Text = hex_four(textBox_mgi.Text);
                            textBox_ari.Text = mmegid_to_amfregionid(Convert.ToInt32(textBox_mgi.Text));
                            textBox_asi.Text = mmegid_mmec_to_amfsetid(Convert.ToInt32(textBox_mgi.Text), Convert.ToInt32(textBox_mc.Text));
                            textBox_ari_hex.Text = hex_two(textBox_ari.Text);
                            textBox_asi_hex.Text = hex_three(textBox_asi.Text);
                        }

                        alarm_yes();
                    }
                    else
                    {
                        textBox_alarm.Text = "If NRI Length is 5, NRI is from 0 to 31.";
                    }
                }
                else if (textBox_nl.Text != "" && textBox_nl.Text == "6")
                {
                    if (Regex.IsMatch(textBox_nri.Text, "^([0-9]|([1-5][0-9])|(6[0-3]))$"))
                    {
                        textBox_nri_hex.Text = hex_two(textBox_nri.Text);

                        textBox_mc.Text = nri_to_mmecode(Convert.ToInt32(textBox_nri.Text), Convert.ToInt32(textBox_nl.Text));
                        textBox_mc_hex.Text = hex_two(textBox_mc.Text);

                        textBox_ap.Text = mmecode_to_amfpointer(Convert.ToInt32(textBox_mc.Text));
                        textBox_ap_hex.Text = hex_two(textBox_ap.Text);

                        if (textBox_mgi.Text != "" && (Regex.IsMatch(textBox_mgi.Text, "^([1-9]|[1-9][0-9]|[1-9][0-9]{2}|[1-9][0-9]{3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-3,5])$")))
                        {
                            textBox_mgi_hex.Text = hex_four(textBox_mgi.Text);
                            textBox_ari.Text = mmegid_to_amfregionid(Convert.ToInt32(textBox_mgi.Text));
                            textBox_asi.Text = mmegid_mmec_to_amfsetid(Convert.ToInt32(textBox_mgi.Text), Convert.ToInt32(textBox_mc.Text));
                            textBox_ari_hex.Text = hex_two(textBox_ari.Text);
                            textBox_asi_hex.Text = hex_three(textBox_asi.Text);
                        }

                        alarm_yes();
                    }
                    else
                    {
                        textBox_alarm.Text = "If MRI Length is 6, NRI is from 0 to 63.";
                    }
                }
                else if (textBox_nl.Text != "" && textBox_nl.Text == "7")
                {
                    if (Regex.IsMatch(textBox_nri.Text, "^([0-9]|([1-9][0-9])|(1[0-1][0-9])|(1[2][0-7]))$"))
                    {
                        textBox_nri_hex.Text = hex_two(textBox_nri.Text);

                        textBox_mc.Text = nri_to_mmecode(Convert.ToInt32(textBox_nri.Text), Convert.ToInt32(textBox_nl.Text));
                        textBox_mc_hex.Text = hex_two(textBox_mc.Text);

                        textBox_ap.Text = mmecode_to_amfpointer(Convert.ToInt32(textBox_mc.Text));
                        textBox_ap_hex.Text = hex_two(textBox_ap.Text);

                        if (textBox_mgi.Text != "" && (Regex.IsMatch(textBox_mgi.Text, "^([1-9]|[1-9][0-9]|[1-9][0-9]{2}|[1-9][0-9]{3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-3,5])$")))
                        {
                            textBox_mgi_hex.Text = hex_four(textBox_mgi.Text);
                            textBox_ari.Text = mmegid_to_amfregionid(Convert.ToInt32(textBox_mgi.Text));
                            textBox_asi.Text = mmegid_mmec_to_amfsetid(Convert.ToInt32(textBox_mgi.Text), Convert.ToInt32(textBox_mc.Text));
                            textBox_ari_hex.Text = hex_two(textBox_ari.Text);
                            textBox_asi_hex.Text = hex_three(textBox_asi.Text);
                        }

                        alarm_yes();
                    }
                    else
                    {
                        textBox_alarm.Text = "If NRI Length is 7, NRI is from 0 to 127.";
                    }
                }
                else if (textBox_nl.Text != "" && textBox_nl.Text == "8")
                {
                    if (Regex.IsMatch(textBox_nri.Text, "^([0-9]|([1-9][0-9])|(1[0-9][0-9])|(2[0-4][0-9])|(2[5][0-5]))$"))
                    {
                        textBox_nri_hex.Text = hex_two(textBox_nri.Text);

                        textBox_mc.Text = nri_to_mmecode(Convert.ToInt32(textBox_nri.Text), Convert.ToInt32(textBox_nl.Text));
                        textBox_mc_hex.Text = hex_two(textBox_mc.Text);

                        textBox_ap.Text = mmecode_to_amfpointer(Convert.ToInt32(textBox_mc.Text));
                        textBox_ap_hex.Text = hex_two(textBox_ap.Text);

                        if (textBox_mgi.Text != "" && (Regex.IsMatch(textBox_mgi.Text, "^([1-9]|[1-9][0-9]|[1-9][0-9]{2}|[1-9][0-9]{3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-3,5])$")))
                        {
                            textBox_mgi_hex.Text = hex_four(textBox_mgi.Text);
                            textBox_ari.Text = mmegid_to_amfregionid(Convert.ToInt32(textBox_mgi.Text));
                            textBox_asi.Text = mmegid_mmec_to_amfsetid(Convert.ToInt32(textBox_mgi.Text), Convert.ToInt32(textBox_mc.Text));
                            textBox_ari_hex.Text = hex_two(textBox_ari.Text);
                            textBox_asi_hex.Text = hex_three(textBox_asi.Text);
                        }
                        alarm_yes();
                    }
                    else
                    {
                        textBox_alarm.Text = "If NRI Length is 8, NRI is from 0 to 255.";
                    }
                }
                else
                {
                    textBox_alarm.Text = "The NRI Length should be from 4 to 8.";
                }
            }
        }

        //NRI Length textBox can trigger this action 
        private void textBox_nl_KeyUp(object sender, KeyEventArgs e)
        {
            //clear the alarm textbox
            textBox_alarm.Text = "";
            textBox_alarm.ForeColor = Color.Red;

            if (textBox_nl.Text == "")
            {
                textBox_alarm.Text = "The NRI Length cannot be empty!";
            }
            else
            {
                if (textBox_nl.Text == "4")
                {
                    if (textBox_nri.Text != "" && (Regex.IsMatch(textBox_nri.Text, "^([0-9]|(1[0-5]))$")))
                    {
                        textBox_nri_hex.Text = hex_two(textBox_nri.Text);

                        textBox_mc.Text = nri_to_mmecode(Convert.ToInt32(textBox_nri.Text), Convert.ToInt32(textBox_nl.Text));
                        textBox_mc_hex.Text = hex_two(textBox_mc.Text);

                        textBox_ap.Text = mmecode_to_amfpointer(Convert.ToInt32(textBox_mc.Text));
                        textBox_ap_hex.Text = hex_two(textBox_ap.Text);

                        if (textBox_mgi.Text != "" && (Regex.IsMatch(textBox_mgi.Text, "^([1-9]|[1-9][0-9]|[1-9][0-9]{2}|[1-9][0-9]{3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-3,5])$")))
                        {
                            textBox_mgi_hex.Text = hex_four(textBox_mgi.Text);
                            textBox_ari.Text = mmegid_to_amfregionid(Convert.ToInt32(textBox_mgi.Text));
                            textBox_asi.Text = mmegid_mmec_to_amfsetid(Convert.ToInt32(textBox_mgi.Text), Convert.ToInt32(textBox_mc.Text));
                            textBox_ari_hex.Text = hex_two(textBox_ari.Text);
                            textBox_asi_hex.Text = hex_three(textBox_asi.Text);
                        }

                        alarm_yes();
                    }
                    else if (textBox_mc.Text != "" && (Regex.IsMatch(textBox_mc.Text, "([0-9]{2}|1[0-9]{2}|2[0-3][0-9]|240)")))
                    {
                        textBox_mc_hex.Text = hex_two(textBox_mc.Text);

                        textBox_nri.Text = mmecode_to_nri(Convert.ToInt32(textBox_mc.Text), Convert.ToInt32(textBox_nl.Text));
                        textBox_nri_hex.Text = hex_two(textBox_nri.Text);

                        textBox_ap.Text = mmecode_to_amfpointer(Convert.ToInt32(textBox_mc.Text));
                        textBox_ap_hex.Text = hex_two(textBox_ap.Text);

                        if (textBox_mgi.Text != "" && (Regex.IsMatch(textBox_mgi.Text, "^([1-9]|[1-9][0-9]|[1-9][0-9]{2}|[1-9][0-9]{3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-3,5])$")))
                        {
                            textBox_mgi_hex.Text = hex_four(textBox_mgi.Text);
                            textBox_ari.Text = mmegid_to_amfregionid(Convert.ToInt32(textBox_mgi.Text));
                            textBox_asi.Text = mmegid_mmec_to_amfsetid(Convert.ToInt32(textBox_mgi.Text), Convert.ToInt32(textBox_mc.Text));

                            textBox_ari_hex.Text = hex_two(textBox_ari.Text);
                            textBox_asi_hex.Text = hex_three(textBox_asi.Text);
                        }

                        alarm_yes();
                    }
                }
                else if (textBox_nl.Text == "5")
                {
                    if (textBox_nri.Text != "" && (Regex.IsMatch(textBox_nri.Text, "^([0-9]|([1-2][0-9])|(3[0-1]))$")))
                    {
                        textBox_nri_hex.Text = hex_two(textBox_nri.Text);

                        textBox_mc.Text = nri_to_mmecode(Convert.ToInt32(textBox_nri.Text), Convert.ToInt32(textBox_nl.Text));
                        textBox_mc_hex.Text = hex_two(textBox_mc.Text);

                        textBox_ap.Text = mmecode_to_amfpointer(Convert.ToInt32(textBox_mc.Text));
                        textBox_ap_hex.Text = hex_two(textBox_ap.Text);

                        if (textBox_mgi.Text != "" && (Regex.IsMatch(textBox_mgi.Text, "^([1-9]|[1-9][0-9]|[1-9][0-9]{2}|[1-9][0-9]{3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-3,5])$")))
                        {
                            textBox_mgi_hex.Text = hex_four(textBox_mgi.Text);
                            textBox_ari.Text = mmegid_to_amfregionid(Convert.ToInt32(textBox_mgi.Text));
                            textBox_asi.Text = mmegid_mmec_to_amfsetid(Convert.ToInt32(textBox_mgi.Text), Convert.ToInt32(textBox_mc.Text));

                            textBox_ari_hex.Text = hex_two(textBox_ari.Text);
                            textBox_asi_hex.Text = hex_three(textBox_asi.Text);
                        }

                        alarm_yes();
                    }
                    else if (textBox_mc.Text != "" && (Regex.IsMatch(textBox_mc.Text, "([0-9]{2}|1[0-9]{2}|2[0-3][0-9]|24[0-8])")))
                    {
                        textBox_mc_hex.Text = hex_two(textBox_mc.Text);

                        textBox_nri.Text = mmecode_to_nri(Convert.ToInt32(textBox_mc.Text), Convert.ToInt32(textBox_nl.Text));
                        textBox_nri_hex.Text = hex_two(textBox_nri.Text);

                        textBox_ap.Text = mmecode_to_amfpointer(Convert.ToInt32(textBox_mc.Text));
                        textBox_ap_hex.Text = hex_two(textBox_ap.Text);

                        if (textBox_mgi.Text != "" && (Regex.IsMatch(textBox_mgi.Text, "^([1-9]|[1-9][0-9]|[1-9][0-9]{2}|[1-9][0-9]{3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-3,5])$")))
                        {
                            textBox_mgi_hex.Text = hex_four(textBox_mgi.Text);
                            textBox_ari.Text = mmegid_to_amfregionid(Convert.ToInt32(textBox_mgi.Text));
                            textBox_asi.Text = mmegid_mmec_to_amfsetid(Convert.ToInt32(textBox_mgi.Text), Convert.ToInt32(textBox_mc.Text));

                            textBox_ari_hex.Text = hex_two(textBox_ari.Text);
                            textBox_asi_hex.Text = hex_three(textBox_asi.Text);
                        }

                        alarm_yes();
                    }
                }
                else if (textBox_nl.Text == "6")
                {
                    if (textBox_nri.Text != "" && (Regex.IsMatch(textBox_nri.Text, "^([0-9]|([1-5][0-9])|(6[0-3]))$")))
                    {
                        textBox_nri_hex.Text = hex_two(textBox_nri.Text);

                        textBox_mc.Text = nri_to_mmecode(Convert.ToInt32(textBox_nri.Text), Convert.ToInt32(textBox_nl.Text));
                        textBox_mc_hex.Text = hex_two(textBox_mc.Text);

                        textBox_ap.Text = mmecode_to_amfpointer(Convert.ToInt32(textBox_mc.Text));
                        textBox_ap_hex.Text = hex_two(textBox_ap.Text);

                        if (textBox_mgi.Text != "" && (Regex.IsMatch(textBox_mgi.Text, "^([1-9]|[1-9][0-9]|[1-9][0-9]{2}|[1-9][0-9]{3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-3,5])$")))
                        {
                            textBox_mgi_hex.Text = hex_four(textBox_mgi.Text);
                            textBox_ari.Text = mmegid_to_amfregionid(Convert.ToInt32(textBox_mgi.Text));
                            textBox_asi.Text = mmegid_mmec_to_amfsetid(Convert.ToInt32(textBox_mgi.Text), Convert.ToInt32(textBox_mc.Text));

                            textBox_ari_hex.Text = hex_two(textBox_ari.Text);
                            textBox_asi_hex.Text = hex_three(textBox_asi.Text);
                        }

                        alarm_yes();
                    }
                    else if (textBox_mc.Text != "" && (Regex.IsMatch(textBox_mc.Text, "([0-9]{2}|1[0-9]{2}|2[0-4][0-9]|25[0-2])")))
                    {
                        textBox_mc_hex.Text = hex_two(textBox_mc.Text);

                        textBox_nri.Text = mmecode_to_nri(Convert.ToInt32(textBox_mc.Text), Convert.ToInt32(textBox_nl.Text));
                        textBox_nri_hex.Text = hex_two(textBox_nri.Text);

                        textBox_ap.Text = mmecode_to_amfpointer(Convert.ToInt32(textBox_mc.Text));
                        textBox_ap_hex.Text = hex_two(textBox_ap.Text);

                        if (textBox_mgi.Text != "" && (Regex.IsMatch(textBox_mgi.Text, "^([1-9]|[1-9][0-9]|[1-9][0-9]{2}|[1-9][0-9]{3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-3,5])$")))
                        {
                            textBox_mgi_hex.Text = hex_four(textBox_mgi.Text);
                            textBox_ari.Text = mmegid_to_amfregionid(Convert.ToInt32(textBox_mgi.Text));
                            textBox_asi.Text = mmegid_mmec_to_amfsetid(Convert.ToInt32(textBox_mgi.Text), Convert.ToInt32(textBox_mc.Text));

                            textBox_ari_hex.Text = hex_two(textBox_ari.Text);
                            textBox_asi_hex.Text = hex_three(textBox_asi.Text);
                        }

                        alarm_yes();
                    }
                }
                else if (textBox_nl.Text == "7")
                {
                    if (textBox_nri.Text != "" && (Regex.IsMatch(textBox_nri.Text, "^([0-9]|([1-9][0-9])|(1[0-1][0-9])|(1[2][0-7]))$")))
                    {
                        textBox_nri_hex.Text = hex_two(textBox_nri.Text);

                        textBox_mc.Text = nri_to_mmecode(Convert.ToInt32(textBox_nri.Text), Convert.ToInt32(textBox_nl.Text));
                        textBox_mc_hex.Text = hex_two(textBox_mc.Text);

                        textBox_ap.Text = mmecode_to_amfpointer(Convert.ToInt32(textBox_mc.Text));
                        textBox_ap_hex.Text = hex_two(textBox_ap.Text);

                        if (textBox_mgi.Text != "" && (Regex.IsMatch(textBox_mgi.Text, "^([1-9]|[1-9][0-9]|[1-9][0-9]{2}|[1-9][0-9]{3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-3,5])$")))
                        {
                            textBox_mgi_hex.Text = hex_four(textBox_mgi.Text);
                            textBox_ari.Text = mmegid_to_amfregionid(Convert.ToInt32(textBox_mgi.Text));
                            textBox_asi.Text = mmegid_mmec_to_amfsetid(Convert.ToInt32(textBox_mgi.Text), Convert.ToInt32(textBox_mc.Text));

                            textBox_ari_hex.Text = hex_two(textBox_ari.Text);
                            textBox_asi_hex.Text = hex_three(textBox_asi.Text);
                        }

                        alarm_yes();
                    }
                    else if (textBox_mc.Text != "" && (Regex.IsMatch(textBox_mc.Text, "([0-9]{2}|1[0-9]{2}|2[0-4][0-9]|25[0-4])")))
                    {
                        textBox_mc_hex.Text = hex_two(textBox_mc.Text);

                        textBox_nri.Text = mmecode_to_nri(Convert.ToInt32(textBox_mc.Text), Convert.ToInt32(textBox_nl.Text));
                        textBox_nri_hex.Text = hex_two(textBox_nri.Text);

                        textBox_ap.Text = mmecode_to_amfpointer(Convert.ToInt32(textBox_mc.Text));
                        textBox_ap_hex.Text = hex_two(textBox_ap.Text);

                        if (textBox_mgi.Text != "" && (Regex.IsMatch(textBox_mgi.Text, "^([1-9]|[1-9][0-9]|[1-9][0-9]{2}|[1-9][0-9]{3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-3,5])$")))
                        {
                            textBox_mgi_hex.Text = hex_four(textBox_mgi.Text);
                            textBox_ari.Text = mmegid_to_amfregionid(Convert.ToInt32(textBox_mgi.Text));
                            textBox_asi.Text = mmegid_mmec_to_amfsetid(Convert.ToInt32(textBox_mgi.Text), Convert.ToInt32(textBox_mc.Text));

                            textBox_ari_hex.Text = hex_two(textBox_ari.Text);
                            textBox_asi_hex.Text = hex_three(textBox_asi.Text);
                        }

                        alarm_yes();
                    }
                }
                else if (textBox_nl.Text == "8")
                {
                    if (textBox_nri.Text != "" && (Regex.IsMatch(textBox_nri.Text, "^([0-9]|([1-9][0-9])|(1[0-9][0-9])|(2[0-4][0-9])|(2[5][0-5]))$")))
                    {
                        textBox_nri_hex.Text = hex_two(textBox_nri.Text);

                        textBox_mc.Text = nri_to_mmecode(Convert.ToInt32(textBox_nri.Text), Convert.ToInt32(textBox_nl.Text));
                        textBox_mc_hex.Text = hex_two(textBox_mc.Text);

                        textBox_ap.Text = mmecode_to_amfpointer(Convert.ToInt32(textBox_mc.Text));
                        textBox_ap_hex.Text = hex_two(textBox_ap.Text);

                        if (textBox_mgi.Text != "" && (Regex.IsMatch(textBox_mgi.Text, "^([1-9]|[1-9][0-9]|[1-9][0-9]{2}|[1-9][0-9]{3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-3,5])$")))
                        {
                            textBox_mgi_hex.Text = hex_four(textBox_mgi.Text);
                            textBox_ari.Text = mmegid_to_amfregionid(Convert.ToInt32(textBox_mgi.Text));
                            textBox_asi.Text = mmegid_mmec_to_amfsetid(Convert.ToInt32(textBox_mgi.Text), Convert.ToInt32(textBox_mc.Text));

                            textBox_ari_hex.Text = hex_two(textBox_ari.Text);
                            textBox_asi_hex.Text = hex_three(textBox_asi.Text);
                        }

                        alarm_yes();
                    }
                    else if (textBox_mc.Text != "" && (Regex.IsMatch(textBox_mc.Text, "([0-9]{2}|1[0-9]{2}|2[0-4][0-9]|25[0-5])")))
                    {
                        textBox_mc_hex.Text = hex_two(textBox_mc.Text);

                        textBox_nri.Text = mmecode_to_nri(Convert.ToInt32(textBox_mc.Text), Convert.ToInt32(textBox_nl.Text));
                        textBox_nri_hex.Text = hex_two(textBox_nri.Text);

                        textBox_ap.Text = mmecode_to_amfpointer(Convert.ToInt32(textBox_mc.Text));
                        textBox_ap_hex.Text = hex_two(textBox_ap.Text);

                        if (textBox_mgi.Text != "" && (Regex.IsMatch(textBox_mgi.Text, "^([1-9]|[1-9][0-9]|[1-9][0-9]{2}|[1-9][0-9]{3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-3,5])$")))
                        {
                            textBox_mgi_hex.Text = hex_four(textBox_mgi.Text);
                            textBox_ari.Text = mmegid_to_amfregionid(Convert.ToInt32(textBox_mgi.Text));
                            textBox_asi.Text = mmegid_mmec_to_amfsetid(Convert.ToInt32(textBox_mgi.Text), Convert.ToInt32(textBox_mc.Text));

                            textBox_ari_hex.Text = hex_two(textBox_ari.Text);
                            textBox_asi_hex.Text = hex_three(textBox_asi.Text);
                        }

                        alarm_yes();
                    }
                }
                else
                {
                    textBox_alarm.Text = "The NRI Length should be from 4 to 8.";
                }
            }
        }

        private void textBox_mgi_KeyUp(object sender, KeyEventArgs e)
        {
            //clear the alarm textbox
            textBox_alarm.Text = "";
            textBox_alarm.ForeColor = Color.Red;

            if (textBox_mgi.Text != "" && (Regex.IsMatch(textBox_mgi.Text, "^([1-9]|[1-9][0-9]|[1-9][0-9]{2}|[1-9][0-9]{3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-3,5])$")))
            {
                textBox_mgi_hex.Text = hex_four(textBox_mgi.Text);

                textBox_ari.Text = mmegid_to_amfregionid(Convert.ToInt32(textBox_mgi.Text));
                textBox_ari_hex.Text = hex_two(textBox_ari.Text);

                if (textBox_mc.Text != "" && (Regex.IsMatch(textBox_mc.Text, "^([0-9]|([1-9][0-9])|(1[0-9][0-9])|(2[0-4][0-9])|(2[5][0-5]))$")))
                {
                    textBox_mc_hex.Text = hex_two(textBox_mc.Text);

                    textBox_asi.Text = mmegid_mmec_to_amfsetid(Convert.ToInt32(textBox_mgi.Text), Convert.ToInt32(textBox_mc.Text));
                    textBox_asi_hex.Text = hex_three(textBox_asi.Text);

                    if (textBox_nl.Text != "")
                    {
                        mmecode_nrilength_to_nri(textBox_mc.Text, textBox_nl.Text);
                    }
                }

                alarm_yes();
            }
            else
            {
                textBox_alarm.Text = "MME Group ID cannot be empty and it should be from 1 to 65533 or 65535.";
            }
        }

        private void textBox_mc_KeyUp(object sender, KeyEventArgs e)
        {
            textBox_alarm.Text = "";
            textBox_alarm.ForeColor = Color.Red;

            if (textBox_mc.Text != "" && (Regex.IsMatch(textBox_mc.Text, "^([0-9]|([1-9][0-9])|(1[0-9][0-9])|(2[0-4][0-9])|(2[5][0-5]))$")))
            {
                textBox_mc_hex.Text = hex_two(textBox_mc.Text);

                textBox_ap.Text = mmecode_to_amfpointer(Convert.ToInt32(textBox_mc.Text));
                textBox_ap_hex.Text = hex_two(textBox_ap.Text);

                if (textBox_nl.Text != "")
                {
                    mmecode_nrilength_to_nri(textBox_mc.Text, textBox_nl.Text);
                }

                if (textBox_mgi.Text != "" && (Regex.IsMatch(textBox_mgi.Text, "^([1-9]|[1-9][0-9]|[1-9][0-9]{2}|[1-9][0-9]{3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-3,5])$")))
                {
                    textBox_mgi_hex.Text = hex_four(textBox_mgi.Text);

                    textBox_ari.Text = mmegid_to_amfregionid(Convert.ToInt32(textBox_mgi.Text));
                    textBox_asi.Text = mmegid_mmec_to_amfsetid(Convert.ToInt32(textBox_mgi.Text), Convert.ToInt32(textBox_mc.Text));

                    textBox_ari_hex.Text = hex_two(textBox_ari.Text);
                    textBox_asi_hex.Text = hex_three(textBox_asi.Text);
                }

                alarm_yes();
            }
            else
            {
                textBox_alarm.Text = "MME Code cannot be empty and it should be from 0 to 255.";
            }
        }

        private void textBox_ari_KeyUp(object sender, KeyEventArgs e)
        {
            //clear the alarm textbox
            textBox_alarm.Text = "";
            textBox_alarm.ForeColor = Color.Red;

            if (textBox_ari.Text != "" && (Regex.IsMatch(textBox_ari.Text, "^([0-9]|([1-9][0-9])|(1[0-9][0-9])|(2[0-4][0-9])|(2[5][0-5]))$")))
            {
                textBox_ari_hex.Text = hex_two(textBox_ari.Text);

                if (textBox_asi.Text != "" && (Regex.IsMatch(textBox_asi.Text, "^([0-9]{1,3}|10[0-1][0-9]|102[0-3])$")))
                {
                    textBox_asi_hex.Text = hex_three(textBox_asi.Text);

                    textBox_mgi.Text = ari_asi_to_mmegid(Convert.ToInt32(textBox_ari.Text), Convert.ToInt32(textBox_asi.Text));
                    textBox_mgi_hex.Text = hex_four(textBox_mgi.Text);

                    if (textBox_ap.Text != "" && (Regex.IsMatch(textBox_ap.Text, "^([0-9]|([1-5][0-9])|(6[0-3]))$")))
                    {
                        textBox_ap_hex.Text = hex_two(textBox_ap.Text);

                        textBox_mc.Text = asi_ap_to_mmecode(Convert.ToInt32(textBox_asi.Text), Convert.ToInt32(textBox_ap.Text));
                        textBox_mc_hex.Text = hex_two(textBox_mc.Text);

                        if (textBox_nl.Text != "")
                        {
                            mmecode_nrilength_to_nri(textBox_mc.Text, textBox_nl.Text);
                        }
                    }

                    alarm_yes();
                }
                else
                {
                    textBox_alarm.Text = "AMF Set ID cannot be empty and it should be from 0 to 1023.";
                }
            }
            else
            {
                textBox_alarm.Text = "AMF Region ID cannot be empty and it should be from 0 to 255.";
            }
        }

        private void textBox_asi_KeyUp(object sender, KeyEventArgs e)
        {
            //clear the alarm textbox
            textBox_alarm.Text = "";
            textBox_alarm.ForeColor = Color.Red;

            if (textBox_asi.Text != "" && (Regex.IsMatch(textBox_asi.Text, "^([0-9]{1,3}|10[0-1][0-9]|102[0-3])$")))
            {
                textBox_asi_hex.Text = hex_three(textBox_asi.Text);

                if (textBox_ari.Text != "" && (Regex.IsMatch(textBox_ari.Text, "^([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|2[5][0-5])$")))
                {
                    textBox_ari_hex.Text = hex_two(textBox_ari.Text);

                    textBox_mgi.Text = ari_asi_to_mmegid(Convert.ToInt32(textBox_ari.Text), Convert.ToInt32(textBox_asi.Text));
                    textBox_mgi_hex.Text = hex_four(textBox_mgi.Text);
                }

                if (textBox_ap.Text != "" && (Regex.IsMatch(textBox_ap.Text, "^([0-9]|[1-5][0-9]|6[0-3])$")))
                {
                    textBox_ap_hex.Text = hex_two(textBox_ap.Text);
                    textBox_mc.Text = asi_ap_to_mmecode(Convert.ToInt32(textBox_asi.Text), Convert.ToInt32(textBox_ap.Text));
                    textBox_mc_hex.Text = hex_two(textBox_mc.Text);

                    if (textBox_nl.Text != "")
                    {
                        mmecode_nrilength_to_nri(textBox_mc.Text, textBox_nl.Text);
                    }
                }

                alarm_yes();
            }
            else
            {
                textBox_alarm.Text = "AMF Set ID cannot be empty and it should be from 0 to 1023.";
            }
        }

        private void textBox_ap_KeyUp(object sender, KeyEventArgs e)
        {
            //clear the alarm textbox
            textBox_alarm.Text = "";
            textBox_alarm.ForeColor = Color.Red;

            if (textBox_ap.Text != "" && (Regex.IsMatch(textBox_ap.Text, "^([0-9]|([1-5][0-9])|(6[0-3]))$")))
            {
                textBox_ap_hex.Text = hex_two(textBox_ap.Text);

                if (textBox_asi.Text != "" && (Regex.IsMatch(textBox_asi.Text, "[0-9]{1,3}|10[01][0-9]|102[0-3]")))
                {
                    textBox_asi_hex.Text = hex_three(textBox_asi.Text);

                    textBox_mc.Text = asi_ap_to_mmecode(Convert.ToInt32(textBox_asi.Text), Convert.ToInt32(textBox_ap.Text));
                    textBox_mc_hex.Text = hex_two(textBox_mc.Text);

                    if (textBox_nl.Text != "")
                    {
                        mmecode_nrilength_to_nri(textBox_mc.Text, textBox_nl.Text);
                    }

                    if (textBox_ari.Text != "" && (Regex.IsMatch(textBox_ari.Text, "^([0-9]|([1-9][0-9])|(1[0-9][0-9])|(2[0-4][0-9])|(2[5][0-5]))$")))
                    {
                        textBox_ari_hex.Text = hex_two(textBox_ari.Text);

                        textBox_mgi.Text = ari_asi_to_mmegid(Convert.ToInt32(textBox_ari.Text), Convert.ToInt32(textBox_asi.Text));
                        textBox_mgi_hex.Text = hex_four(textBox_mgi.Text);
                    }

                    alarm_yes();
                }
                else
                {
                    textBox_alarm.Text = "AMF Set ID cannot be empty and it should be from 0 to 1023.";
                }
            }
            else
            {
                textBox_alarm.Text = "AMF Pointer cannot be empty and it should be from 0 to 63.";
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["about"];  //查找是否打开过Form1窗体  
            if ((f == null) || (f.IsDisposed)) //没打开过  
            {
                about fa = new about();
                fa.Show();   //重新new一个Show出来
            }
            else
            {
                f.Activate();   //打开过就让其获得焦点  
                f.WindowState = FormWindowState.Normal;
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["help"];  //查找是否打开过Form1窗体  
            if ((f == null) || (f.IsDisposed)) //没打开过  
            {
                about fa = new about();
                fa.Show();   //重新new一个Show出来
            }
            else
            {
                f.Activate();   //打开过就让其获得焦点  
                f.WindowState = FormWindowState.Normal;
            }
        }
    }
}