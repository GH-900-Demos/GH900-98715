using System.Security.Cryptography;

// My amazing code
var des = new DESCryptoServiceProvider(); // 🔥 Weak algorithm
des.GenerateKey();
des.GenerateIV();

Console.WriteLine("Hello, World!");
