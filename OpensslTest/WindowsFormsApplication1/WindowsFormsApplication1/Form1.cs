using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// add [2/19/2019 yongchao]
using System.Security.Cryptography;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ////加密解密用到的公钥与私钥
            //RSACryptoServiceProvider oRSA = new RSACryptoServiceProvider();
            //string privatekey = oRSA.ToXmlString(true);//私钥
            //string publickey = oRSA.ToXmlString(false);//公钥
            //string privatekey = @"<RSAKeyValue><Modulus>qRVPGjc7V9t6wJBqrvVC2wr+R035JwZn1Npx5AvmjS75EP9/bAezEknLeaqE9Ny/H56OowMJBOnU01uIK1FCK1p0r1Mv/wUIa+kvEDr6vjxVca/hF7v8qDS06rBBUGttciwnZepQAyCa+syiBn4o21FaeqPCgTNxyphDyt8HQH0=</Modulus><Exponent>AQAB</Exponent><P>00OA34tqkjjfKZCR1sMNg3MSW7hJyYX0feDAlhpKEaKs5K7W6oGG4R2hlBeRduobMcBWFJjyVcQbKnUhze6MwQ==</P><Q>zOM5nndtL3nXNqfR1pC150BZMKckJGDU3XzOXbs4EyOk1YHL32+WPkWblz0DGJWQtmBpofdAKGjwEBcQPEDWvQ==</Q><DP>VsW1GxxCS4i8cHAG1rUKyeDru2x4MiOpBkLYF074+UFdzhfaAjvtUG1BPnhnsPX68XZUZOVlM8D2f3vYxKKkgQ==</DP><DQ>XgxTj5UcbnWMP49rOAW3Kg6UokumwHgeXgkDJW1iAQ8Ug9kPv2GWYsFK+XJNMIS/J6g79NftAF+jCo+7qRzONQ==</DQ><InverseQ>t0LtVQ50gersNp1aS3Jg4cDlFQ2o9diGjsuJaV/WY8PN+L+KubQbPaI0tCGnz+vGrhyRKYfLCIq0xg3JO6DKMA==</InverseQ><D>AoXw4kFEv3DlCg6dqPK8BqzJUqMVPsHXttNzs6WB0UWMLfbCHgiXYYR8ZtpmlYjdyUkCc+hNsCcVJ/pLs+nIhPrkwuyTeeyFUOo0VCrg/Qk308Of4brTlLnFlfbf3Pos8E0DE7Jd+Cy4ejn3/+VB3RVC6Uk04PvPhNOPM9apSgE=</D></RSAKeyValue>";
            //string publickey = @"<RSAKeyValue><Modulus>qRVPGjc7V9t6wJBqrvVC2wr+R035JwZn1Npx5AvmjS75EP9/bAezEknLeaqE9Ny/H56OowMJBOnU01uIK1FCK1p0r1Mv/wUIa+kvEDr6vjxVca/hF7v8qDS06rBBUGttciwnZepQAyCa+syiBn4o21FaeqPCgTNxyphDyt8HQH0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

            ////这两个密钥需要保存下来
            //byte[] messagebytes = { 0x00,0x30,0x00,0x01,0x01,0x00,0x02,0x00,0x01,0x01,0x00,0x00,0x01,0x04,0x00,0x00,0x00,0x01};// Encoding.UTF8.GetBytes("luo罗"); //需要加密的数据
            ////公钥加密
            //RSACryptoServiceProvider oRSA1 = new RSACryptoServiceProvider();
            //oRSA1.FromXmlString(publickey); //加密要用到公钥所以导入公钥
            //byte[] AOutput = oRSA1.Encrypt(messagebytes ,false); //AOutput 加密以后的数据

            ////私钥解密
            //RSACryptoServiceProvider oRSA2 = new RSACryptoServiceProvider();
            //oRSA2.FromXmlString(privatekey);          
            //byte[] AInput = oRSA2.Decrypt(AOutput, false);
            //string reslut=Encoding.ASCII.GetString(AInput) ;

            ////私钥签名
            //RSACryptoServiceProvider oRSA3 = new RSACryptoServiceProvider();
            //oRSA3.FromXmlString(privatekey);
            //byte[] AOutput1 = oRSA3.SignData(messagebytes, "SHA1");
            ////公钥验证
            //RSACryptoServiceProvider oRSA4 = new RSACryptoServiceProvider();
            //oRSA4.FromXmlString(publickey);
            //bool bVerify = oRSA4.VerifyData(messagebytes, "SHA1", AOutput1);

            //RSACryptoServiceProvider oRSA5 = new RSACryptoServiceProvider();
            //oRSA5.FromXmlString(publickey);
            //byte[] AInput1 = oRSA5.Decrypt(AOutput1, false);
            //reslut = Encoding.ASCII.GetString(AInput1);

            //////////////////////////////////////////////////////////////////////////
            //加密解密用到的公钥与私钥
            RSACryptoServiceProvider oRSA = new RSACryptoServiceProvider();
            //string privatekey=oRSA.ToXmlString(true);//私钥
            //string publickey=oRSA.ToXmlString(false);//公钥
            string privatekey = @"<RSAKeyValue><Modulus>6aIychRQraQANKoTJBZ/gjlk8oZ4eXfSy8uoqQR60petcJ2ZK4hJ59J+UdKRbP91W619lDlbyIWZm0mtfuuo2v1sZBboW45h6XSHWPa92xWvr8PJ+lWZdArmavgWjKWwoXlkUxTOx2xEYDtULUouOknhnLDfTu2whj4O0WmGOc9A2rlMKERQi+hVtud4UqPeJcQ4jC15KrZv/s9wsrvUXfklVM4JjrFHZvJa6cn83GrIbgPybWlD3UdF2Ty/DMsjixExozXG4tLOTyrLncXW6QmfOI8/xzbigUwtJmhV36X1xKMnJ6mySL8ttQGL3+wJkljppgEl2vcY5OfBpXuEZw==</Modulus><Exponent>Aw==</Exponent><P>+m1Wkdnw286Fw/6KJiXvUX/sEYn4z/84lOuKIw2uNxOblgKSaNaGI6z+JXKuN/11JCdhKYe0e9vK51oDbH9X5f0xWLRbSjWCndpMCVVmVZM1h6xcPwi1+vWNMZpUzvZ3ur0phQL3ODPQj4e0QWDKFIV1bDMI6RXiCkEn0LtJ7gs=</P><Q>7tUwCScfDL6cq6OsySyA1auPJkAsrCDmRJfiwxozZypzyzZL0QQEuiJbdDQ3EtIoN0VSVz3fbf9SEnwyhf5qQYfnt2C0ARMIg6BrYzq080u1/1IrHspsnRvQ4W8G+TPiMNCw+ccMC6PO/jrNx5UIruiQnFgeTiSz4EGRJ/Fu6JU=</Q><DP>pvOPC+agkomugqmxbsP04P/ytlv7NVTQY0exbLPJeg0SZAG28I8EF8ipbkx0JVOjbW+WG6/Np+fcmjwCSFTlQ/4g5c2SMXkBvpGIBjju47d5BR2S1LB5UfkIy7w4ifmlJyjGWKyk0CKLClp4K5XcDa5OSCIF8LlBXCtv4Hzb9Ac=</DP><DQ>nzjKsMS/XdRocm0d23MAjnJfbtVzHWtELbqXLLwiRMb33M7dNgKt0Ww8+CLPYeFwJNjhj36U8/+MDFLMWVRG1lqaekB4ALdbAmryQicjTN0j/4wcvzGdvhKLQPSvUM1BdeB1+9oIB8KJ/tHehQ4FyfBgaDq+3sMilYELb/ZJ8GM=</DQ><InverseQ>33dIOAA2U7w0P9Aik2O34VESF/JGs8gKT3himZO52Zh0JCdULtm5lE0gdPJAie/fdWnImyXTOn3HpgXFB2jm0jKKUIDeXCEh3mYeXXrB2Ff3oAkR8ihCVfZeVi6eocUCkVNZu9oXzyCeZbkf9GIfeS9VijuhgKUvcMoFgGv+QDI=</InverseQ><D>m8F29rg1yRgAIxwMwrmqVtDt9wRQUPqMh90bG1hR4bpzoGkQx7AxRTb+4TcLnf+jknOpDXuSha5mZ4ZzqfJwkf5IQrnwPQmWm6ME5fnT52PKdS0xUY5mTVyZnKVkXcPLFlDtjLiJ2kgtlXziyNwe0YaWaHXqNJ51rtQJ4PEEJojlECHLb3hFVIPuuHWwqs0kpttV1q/+Bw+5p5cHBzwkFUaCvUqKeBmbumXWLJh2szOeAOBLxTjmrBwyrK8zCgX9WVAWXsRSZtpzOEzqCRxesWllfAVBTWLcSp68E12zzjKxedsa6Rme9hUVTFUB8WYuwuHrZzv0aut0QXSF+yxz2w==</D></RSAKeyValue>";
            //string publickey = @"<RSAKeyValue><Modulus>qRVPGjc7V9t6wJBqrvVC2wr+R035JwZn1Npx5AvmjS75EP9/bAezEknLeaqE9Ny/H56OowMJBOnU01uIK1FCK1p0r1Mv/wUIa+kvEDr6vjxVca/hF7v8qDS06rBBUGttciwnZepQAyCa+syiBn4o21FaeqPCgTNxyphDyt8HQH0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

            //这两个密钥需要保存下来
            byte[] messagebytes = { 0x00, 0x30, 0x00, 0x01, 0x01, 0x00, 0x02, 0x00, 0x01, 0x01, 0x00, 0x00, 0x01, 0x04, 0x00, 0x00, 0x00, 0x01 };// Encoding.UTF8.GetBytes("luo罗"); //需要加密的数据


            //私钥生成公钥
            RSACryptoServiceProvider oRSA1 = new RSACryptoServiceProvider();
            oRSA1.FromXmlString(privatekey);

            string publickey = oRSA1.ToXmlString(false);


            //公钥加密
            RSACryptoServiceProvider oRSA2 = new RSACryptoServiceProvider();
            oRSA1.FromXmlString(publickey); //加密要用到公钥所以导入公钥

            byte[] AOutput = oRSA2.Encrypt(messagebytes, false); //AOutput 加密以后的数据

            //私钥解密
            RSACryptoServiceProvider oRSA3 = new RSACryptoServiceProvider();
            oRSA3.FromXmlString(privatekey);

            string publickeyTemp = oRSA3.ToXmlString(false);

            byte[] AInput = oRSA3.Decrypt(AOutput, false);
            string reslut = Encoding.ASCII.GetString(AInput);


            
           

        }
        public static string RSAEncrypt(string xmlPublicKey, string plainText)
        {
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            provider.FromXmlString(xmlPublicKey);
            byte[] bytes = new UnicodeEncoding().GetBytes(plainText);
            return Convert.ToBase64String(provider.Encrypt(bytes, false));
        }
    }
}
