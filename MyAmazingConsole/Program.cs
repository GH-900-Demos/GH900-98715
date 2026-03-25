using System.Security.Cryptography;

var des = new DESCryptoServiceProvider(); // 🔥 Weak algorithm
des.GenerateKey();
des.GenerateIV();

Console.WriteLine("Hello, World!");
