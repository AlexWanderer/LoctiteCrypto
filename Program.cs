using HackForums.gigajew;
using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // single instance, disposable class
            LoctiteCrypto crypto = new LoctiteCrypto(/* key size */2048, /* big endian (text) format */ true, /* byte order marker (text) */ false);

            // this is your private key, do not share with any clients, you use this
            // to decrypt any data
            string private_key = "<RSAKeyValue><Modulus>oBWpOIIk6CTRSINqjpA4UHwoWeSQId7lDCW5N26/JWnWP0snIRq0M6jqq06O3czqgbtuuAJvHI7GE+2i+5F+dz1uBHgBLJrfN5/FRe6zYThfTXsDdKRND3bZta2XnhyUFLSnqvHleag/E2RSPxTBjurDIZiR/2rRYRL74GBxA5k/9uddcOyXiCD/WrRr/5ewOZbphUp3ppxL/0sYeqdiOPaNATCModGoiD6N+iaJpSJpXbATmta4kdH5cuyIg6waT2DpCdjHf4eETMHkV/HV8YYgtuv1Dohm3gnBuelmcCmOi5xOgvE+jXwSShHUpxnpHB09WXyrvH1Sn4mvCbE+AejqJTVkGwJegUejOdVkKutZVOoRItJwX1cbvaeH7okNxomm6G8H+7QjLkHBciCaUXRxWOmaJu2jP44yPJ5TfcqL1ntdCTTd+Wzir6mQ7agfP9qSXdMndkeD9puAowAMGzR5PkzEluNwMmj7HrgAK/QkFrES9+QvrokboU35Q3up</Modulus><Exponent>AQAB</Exponent><P>x6H80Z2QlJmr5ZuQkc0LvNovfK3m309+BCCefuENyfvLqOXCIpvvAHiD4i34tBso1NxvkXDOx9OWCh/hHQTby8ZtEydBORrfPRS5n/EE9deoHcvPyBI667/JRB7sKySjOntxVzV+Kre/fEmmrYZb/0IhuF4OPm/+Jd6d1tJ5e+3xi8TtJAWHuWs0wbbyg9+s+eSnesZQC6khXpEjb/cI2MXWHTlgj40jax5FSLxASNLy0qfEF3jydS6HrcKRakwn</P><Q>zUkF3lrFX5LqMY6C+rSISSgG4Zij/dISP+LJSNoKLYgzgun/l/YRBNjqPcxHlqC2+12kX3y/DJBw8DKAup1r/2j3eR9n4u4AniT/3UIMfyvT6vtIRRkAh3JuJBo5i3QduRCVG2Vo0KSVLzr215vQp6Ovy/4L+f0kYoKRoamlE7s3NDh0wr3aTgpr7RZEYIOWLq+fkxBoGehwnPHTo0wR4J0+ONii7r4k7z1t6oaTGJRBemkTICDtmgaq2t4Upkuv</Q><DP>PWy9Qq4Nn3uNJa/xEruZofksZVuIzytBZfm3aujKelysdIKFcmqyZl2ujriAbsJwlNZiyciBB4E2CFV4yZoGGzQpuZv5eJ2pFL08xFa/pPk/NDPS8geR85nmTryJBFlYlBUJccD22iQBmjd7Pqc5xVfO0lC2Z0XEWFigDkpisNws10m3gb7l3Qp8iCJHioYXTiip06ATXxMiPlvAIKJNKY3t7L4L1P+jZ0FAJjouOXoW1vRh5KsFR0MS4kccwS0/</DP><DQ>EPlnxdIFnfh86uoYxHgnCL2JjB/d93/mSGgNMrvsuYUYlUuZ+cu77oWtIL0Ccl8JolFE5Sxgc76ByCq04DliE7VvORGyul3pqSnwCjCK7f0GwdhTSntdwtVgbBXLCk/ooUPQwHorJ41kVIpwnLVilGoBgEGaZepbltWrCw4G+1Gwp92/MdcW9PsBn5IGx2A6C9QzwqpJoVLJ9QA9+rOwir0VxweKuWj5jtqqewjzosWngGKt1StD2keQ2xYf6Pw7</DQ><InverseQ>NbQWce9JvSbRjS20i0aH/nKUS2LX50mS3epHHJvdKmHyUWQ2HF/wcObwJDSvwkA7QOMpZpbtglWP1ocHnlDf871WM7XIqpNnEMeXZu1gVs4xz9ngsK1qiH9rm51wCpmcE0MGuXSnJpcyvvsY42wZx7BU3wNaC7SK0j6iXwSxVZdaju+bY5xKTYP021fETjsAjELBOePwh6FWaX4ipIlCkCcbPlfgwXQn/FTfQwI/9qMWbWShYUUhpxzypyMizYDA</InverseQ><D>ZZF4vVatbfC2LEjdGbjdUguEWoyO+j5+mrdwjYAhnO5KtfvLxtA3lzNMOQZt1MJH46n1NKCuuLLJcCltKCoG0EbUf9dX/2H/0D35n0Y037Exnmo3JhF8pxwkQ4XxVasSNRTt8KLrksWxx272U/mqWTAQQEeaEjFGyU2PK6xk6ACaud/PxG8IMaGmAnnIr/EhKVjbrusxgS9XdJHD5UZAJp4flqqj/6OTR2ZRFG7RFEoCCiRGPA6SKkrL9yOl9c0CH4PgdBPYVq+Jxc0d94Ww/WnEDRxehRuXe0AeX28L8LYygni4tgTgGurbH624PuaXBWQKiMGNGw65lQjCXMlrZAtPfVmyoUXRGjBnpXxj9/A10zG5Ugi1pkI98QpJHO7E/3VWEoxVp+8OIps4qQxArl8xf12L1toHULEpOSHu7UuXn9Ssuwy/tCTJ5tvn8EuVTNsXu5cRVWcrMcI+vUkG6aY+XK2yiBU56nV6tSSyF41WMloMrxM284L8uOB3kilF</D></RSAKeyValue>";

            // this is your public key, clients use this to encrypt their data
            string public_key = "<RSAKeyValue><Modulus>oBWpOIIk6CTRSINqjpA4UHwoWeSQId7lDCW5N26/JWnWP0snIRq0M6jqq06O3czqgbtuuAJvHI7GE+2i+5F+dz1uBHgBLJrfN5/FRe6zYThfTXsDdKRND3bZta2XnhyUFLSnqvHleag/E2RSPxTBjurDIZiR/2rRYRL74GBxA5k/9uddcOyXiCD/WrRr/5ewOZbphUp3ppxL/0sYeqdiOPaNATCModGoiD6N+iaJpSJpXbATmta4kdH5cuyIg6waT2DpCdjHf4eETMHkV/HV8YYgtuv1Dohm3gnBuelmcCmOi5xOgvE+jXwSShHUpxnpHB09WXyrvH1Sn4mvCbE+AejqJTVkGwJegUejOdVkKutZVOoRItJwX1cbvaeH7okNxomm6G8H+7QjLkHBciCaUXRxWOmaJu2jP44yPJ5TfcqL1ntdCTTd+Wzir6mQ7agfP9qSXdMndkeD9puAowAMGzR5PkzEluNwMmj7HrgAK/QkFrES9+QvrokboU35Q3up</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

            // a sample client message
            string secret_message = "Hello world";

            // client encrypts data
            EncryptedBlob blob = crypto.EncryptString(secret_message, public_key);

            Console.WriteLine(Convert.ToBase64String(blob.EncryptedData));

            // server decrypts data
            string decrypted = crypto.DecryptString(blob, private_key);

            // print out decrypted result
            Console.WriteLine(decrypted);
            Console.ReadLine();

            // free up resources
            crypto.Dispose();
        }
    }
}
