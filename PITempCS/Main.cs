using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PITempCS
{
    
    /// <summary>メインの機能をここに実装する。</summary>
    static internal class Main
  {
        static internal int status = 0;
        static internal int soundIndex = 20;
        static internal string stopKey = "H";
        static int inputKeyCode = 11;
        static internal void Load()
    {
#if DEBUG
            //MessageBox.Show("PITempCS Debug Build");//If you don't need, please remove it.
#endif
            string stTarget = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            string dllPath = "";
            //ローカルファイルのパスを表すURI
            string uriPath = stTarget;
            //Uriオブジェクトを作成する
            Uri u = new Uri(uriPath);
            //変換するURIがファイルを表していることを確認する
            if (u.IsFile)
            {
                //Windows形式のパス表現に変換する
                dllPath = u.LocalPath + Uri.UnescapeDataString(u.Fragment);
            }
            else
            {
                MessageBox.Show("ファイルURIではありません。");
            }

            string dir = Path.GetDirectoryName(dllPath);
            string name = Path.GetFileNameWithoutExtension(dllPath);
            string path = dir + @"\" + name + ".ini";

            
            try
            {
                if (File.Exists(path))
                {
                    //MessageBox.Show("Exist!" + path);

                    //読み込むテキストファイル
                    string textFile = @path;
                    //文字コード(ここでは、Shift JIS)
                    Encoding enc = Encoding.GetEncoding("shift_jis");

                    //テキストファイルの中身をすべて読み込む
                    string str = File.ReadAllText(textFile, enc);

                    //行ごとの配列として、テキストファイルの中身をすべて読み込む
                    string[] lines = File.ReadAllLines(textFile, enc);

                    int soundIndexTemp = 0;
                    string inputKeyTemp = "S";


                    for(int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].StartsWith("SoundPlayInit", StringComparison.OrdinalIgnoreCase))
                        {
                            soundIndexTemp = Convert.ToInt16(lines[i].Substring(lines[i].IndexOf('=') + 1));
                        }
                        if(lines[i].StartsWith("InputKey", StringComparison.OrdinalIgnoreCase))
                        {
                            inputKeyTemp = lines[i].Substring(lines[i].IndexOf('=') + 1).Trim();                           
                        }
                    }



                    switch (inputKeyTemp)
                    {
                        case "S":
                            inputKeyCode = ATSKeys.S;
                            break;
                        case "A1":
                            inputKeyCode = ATSKeys.A1;
                            break;
                        case "A2":
                            inputKeyCode = ATSKeys.A2;
                            break;
                        case "B1":
                            inputKeyCode = ATSKeys.B1;
                            break;
                        case "B2":
                            inputKeyCode = ATSKeys.B2;
                            break;
                        case "C1":
                            inputKeyCode = ATSKeys.C1;
                            break;
                        case "C2":
                            inputKeyCode = ATSKeys.C2;
                            break;
                        case "D":
                            inputKeyCode = ATSKeys.D;
                            break;
                        case "E":
                            inputKeyCode = ATSKeys.E;
                            break;
                        case "F":
                            inputKeyCode = ATSKeys.F;
                            break;
                        case "G":
                            inputKeyCode = ATSKeys.G;
                            break;
                        case "H":
                            inputKeyCode = ATSKeys.H;
                            break;
                        case "I":
                            inputKeyCode = ATSKeys.I;
                            break;
                        case "J":
                            inputKeyCode = ATSKeys.J;
                            break;
                        case "K":
                            inputKeyCode = ATSKeys.K;
                            break;
                        case "L":
                            inputKeyCode = ATSKeys.L;
                            break;

                        default:
                            inputKeyCode = ATSKeys.H;
                            break;
                    }

                    if (soundIndexTemp >= 0 && soundIndexTemp < 256)
                    {
                        //正常処理
                        soundIndex = soundIndexTemp;
                        stopKey = inputKeyTemp;
                        //MessageBox.Show("soundIndex =" + soundIndex+"\r\n"+"\r\n" + "inputKey =" + inputKeyTemp);
                    }

                }
                else
                {
                    //MessageBox.Show("Nothiing!" + path);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Dispose();
            }

        }

    static internal void Dispose()
    {

    }

    static internal void GetVehicleSpec(Spec s)
    {

    }

    static internal void Initialize(int s)
    {

    }
    //Attention! This Method uses "UNSAFE".
    static unsafe internal void Elapse(State st, int* Pa, int* Sa)
    {
            //If you want to change the Handle state, please access to Ats.Handle

            if(status == 0)
            {
                Sa[soundIndex] = Sound.Stop;
                status = 1;
            }
            else if(status == 1)
            {
                Sa[soundIndex] = Sound.Loop;
            }
            else if(status == 2)
            {
                Sa[soundIndex] = Sound.Stop;
            }
    }

    static internal void SetPower(int p)
    {

    }

    static internal void SetBrake(int b)
    {

    }

    static internal void SetReverser(int r)
    {

    }
    static internal void KeyDown(int k)
    {
            if (k == inputKeyCode)
            {
                status = 2;
            }
    }

    static internal void KeyUp(int k)
    {

    }

    static internal void DoorOpen()
    {

    }
    static internal void DoorClose()
    {

    }
    static internal void HornBlow(int h)
    {

    }
    static internal void SetSignal(int s)
    {

    }
    static internal void SetBeaconData(Beacon b)
    {

    }
  }
}
