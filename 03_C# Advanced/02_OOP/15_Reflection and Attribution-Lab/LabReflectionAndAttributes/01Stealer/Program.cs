﻿
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();

            string result = spy.StealFieldInfo("Hacker", "username", "password");
            Console.WriteLine(result);
        }
    }

