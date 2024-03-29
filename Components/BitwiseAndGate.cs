﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    //A two input bitwise gate takes as input two WireSets containing n wires, and computes a bitwise function - z_i=f(x_i,y_i)
    class BitwiseAndGate : BitwiseTwoInputGate
    {
        //your code here
        private AndGate[] andGates;

        public BitwiseAndGate(int iSize)
            : base(iSize)
        {
            //your code here
            andGates = new AndGate[iSize];
            for (int i = 0; i < andGates.Length; i++)
                andGates[i] = new AndGate();

            for (int i = 0; i < iSize; i++)
            {
                andGates[i].ConnectInput1(this.Input1[i]);
                andGates[i].ConnectInput2(this.Input2[i]);
            }

            for (int i = 0; i < iSize; i++)
            {
                Output[i].ConnectInput(andGates[i].Output);
            }
        }

        //an implementation of the ToString method is called, e.g. when we use Console.WriteLine(and)
        //this is very helpful during debugging
        public override string ToString()
        {
            return "And " + Input1 + ", " + Input2 + " -> " + Output;
        }

        public override bool TestGate()
        {
            Input1[0].Value = 0;
            Input2[0].Value = 0;
            if (Output[0].Value != 0)
                return false;
            Input1[0].Value = 0;
            Input2[0].Value = 1;
            if (Output[0].Value != 0)
                return false;
            Input1[0].Value = 1;
            Input2[0].Value = 0;
            if (Output[0].Value != 0)
                return false;
            Input1[0].Value = 1;
            Input2[0].Value = 1;
            if (Output[0].Value != 1)
                return false;
            return true;
        }
    }
}
