using System;
using UnityEngine;
using UnityEngine.UI;
namespace Calculator
{

    public enum StatesButton 
    {
        plus,
        ravno,
        minus,
        um,
        del,
        tochka

    }

    public enum StatesInput 
    {
        param1,
        param2,
        rezult
    }
    public class calculateManager : MonoBehaviour
    {
        public Button[] numsBtns;
        public Button Plus;
        public Button Ravno;
        public Button Minus;
        public Button Tochka;
        public Button Del;
        public Button UM;
        public Text Output; 
        public StatesInput InputState;  
        public StatesButton Znak;
        public string pervyPar;
        public string vtoroyPar;
        void Start()
        {
            for (int i = 0; i < numsBtns.Length; i++)
            {
                var i1 = i;
                numsBtns[i].onClick.AddListener( () => onClickNum(i1));
            }
            Plus.onClick.AddListener(()=> onClickPlus());
            Ravno.onClick.AddListener(()=>onClickRavno());
            Minus.onClick.AddListener(()=>onClickMinus());
            UM.onClick.AddListener(()=>onClickUM());
            Tochka.onClick.AddListener(()=>onClickTochka());
            Del.onClick.AddListener(()=>onClickDel());
        }
        void onClickNum(int Numb)
        {
            switch (InputState)
            {
                case StatesInput.param1:
                    pervyPar += Numb;
                    Output.text = pervyPar;
                    break;
                case StatesInput.param2:
                    vtoroyPar += Numb;
                    Output.text = vtoroyPar;
                    break;
                case StatesInput.rezult:
                    InputState = StatesInput.param1;
                    pervyPar += Numb;
                    Output.text = pervyPar;
                    break;
            }
        }
        void onClickPlus()
        {
            Znak = StatesButton.plus;
            switch (InputState)
            {
                case StatesInput.param1:
                    InputState = StatesInput.param2;
                    break;
                case StatesInput.param2:
                    pervyPar = vtoroyPar;
                    break;
                case StatesInput.rezult:
                    pervyPar = Output.text;
                    InputState = StatesInput.param2;
                    break;
               
            }
        }

        void onClickMinus()
        {
            Znak = StatesButton.minus;
            switch (InputState)
            {
                case StatesInput.param1:
                    InputState = StatesInput.param2;
                    break;
                case StatesInput.param2:
                    pervyPar = vtoroyPar;
                    break;
                case StatesInput.rezult:
                    pervyPar = Output.text;
                    InputState = StatesInput.param2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void onClickUM()
        {
            Znak = StatesButton.um;
            switch (InputState)
            {
                case StatesInput.param1:
                    InputState = StatesInput.param2;
                    break;
                case StatesInput.param2:
                    pervyPar = vtoroyPar;
                    break;
                case StatesInput.rezult:
                    pervyPar = Output.text;
                    InputState = StatesInput.param2;
                    break;
            }
        }

        void onClickTochka()  // Точку пытался сделать, вроде выводит числа на экран, но как дойти до вывода результата
                             // допетрить не могу
        {
            Znak = StatesButton.tochka;
            switch (InputState)
            {
                case StatesInput.param1:
                    pervyPar += ".";
                    Output.text = pervyPar;
                    break;
                case StatesInput.param2:
                    vtoroyPar += ".";
                    Output.text = vtoroyPar;
                    break;
                case StatesInput.rezult:
                    pervyPar = Output.text;
                    InputState = StatesInput.param2;
                    break;
                
            }
        }
        
        void onClickRavno()
        {
            switch (Znak)
            {
                case StatesButton.plus:
                    Znak = StatesButton.ravno;
                    InputState = StatesInput.rezult;
                    var p1 = string.IsNullOrEmpty(pervyPar) ? 0 : Convert.ToInt32(pervyPar);
                    var p2 = string.IsNullOrEmpty(vtoroyPar) ? 0 : Convert.ToInt32(vtoroyPar);
                    Output.text = (p1 + p2).ToString();
                    break;
                case StatesButton.minus:
                    Znak = StatesButton.ravno;
                    InputState = StatesInput.rezult;
                    var pr1 = string.IsNullOrEmpty(pervyPar) ? 0 : Convert.ToInt32(pervyPar);
                    var pr2 = string.IsNullOrEmpty(vtoroyPar) ? 0 : Convert.ToInt32(vtoroyPar);
                    Output.text = (pr1 - pr2).ToString();
                    break;
                case StatesButton.um:
                    Znak = StatesButton.ravno;
                    InputState = StatesInput.rezult;
                    var s1 = string.IsNullOrEmpty(pervyPar) ? 0 : Convert.ToInt32(pervyPar);
                    var s2 = string.IsNullOrEmpty(vtoroyPar) ? 0 : Convert.ToInt32(vtoroyPar);
                    Output.text = (s1 * s2).ToString();
                    break;
                case StatesButton.del:
                    Znak = StatesButton.ravno;
                    InputState = StatesInput.rezult;
                    var d1 = string.IsNullOrEmpty(pervyPar) ? 0 : Convert.ToInt32(pervyPar);
                    var d2 = string.IsNullOrEmpty(vtoroyPar) ? 0 : Convert.ToInt32(vtoroyPar);
                    Output.text = (" ").ToString();
                    break;
                case StatesButton.tochka:
                    Znak = StatesButton.ravno;
                    InputState = StatesInput.rezult;
                    var t1 = string.IsNullOrEmpty(pervyPar) ? 0 : Convert.ToInt32(pervyPar);
                    var t2 = string.IsNullOrEmpty(vtoroyPar) ? 0 : Convert.ToInt32(vtoroyPar);
                    Output.text = (t1+"."+t2).ToString();
                    break;
                case StatesButton.ravno:
                    break;
            }

            pervyPar = "";
            vtoroyPar = "";
        }

        void onClickDel()
        {
            Znak = StatesButton.del;
            switch (InputState)
            {
                case StatesInput.param1:
                    pervyPar = Output.text;
                    Output.text = "";
                    pervyPar = "";
                    break;
                case StatesInput.param2:
                    vtoroyPar = Output.text;
                    Output.text = "";
                    vtoroyPar = "";
                    break;
                case StatesInput.rezult:
                    pervyPar = Output.text;
                    Output.text = "";
                    pervyPar = "";
                    break;
            }
        }
    }
}

