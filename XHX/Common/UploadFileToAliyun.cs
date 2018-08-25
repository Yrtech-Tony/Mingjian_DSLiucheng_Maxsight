using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aliyun.OpenServices.OpenStorageService;
using System.IO;

namespace XHX.Common
{

    public class UploadFileToAliyun
    {
        const string accessid = "fjXqGY0cmLUUG5wA";
        const string accessKey = "i56mAj3sDjAfQc7tFFtBKv1SY9t58i";
        const string endpoin = "http://oss-cn-beijing.aliyuncs.com";
        //const string endpoin = "oss-cn-beijing-internal.aliyuncs.com";
        

        OssClient ossClient = null;
        public UploadFileToAliyun()
        {
            ossClient = new OssClient(endpoin, accessid, accessKey);
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="bucketName"></param>
        /// <param name="key"></param>
        /// <param name="fileToUpload"></param>
        public void PutObject(string bucketName, string key, string fileToUpload)
        {
            using (var fs = File.Open(fileToUpload, FileMode.Open))
            {
                var metadata = new ObjectMetadata();
                metadata.UserMetadata.Add("key0", "val0");
                metadata.ContentLength = fs.Length;
                var result = ossClient.PutObject(bucketName, key, fs, metadata);

            }

        }
        public void PutObjectMultipart(string bucketName, string key, string fileToUpload)
        {
            var partSize = 1000*1000;
            var initRequest = new InitiateMultipartUploadRequest(bucketName, key);
            var uploadId = ossClient.InitiateMultipartUpload(initRequest);
            var fi = new FileInfo(fileToUpload);
            var fileSize = fi.Length;
            var parCount = fileSize / partSize;
            if (fileSize % partSize != 0)
            {
                parCount++;
            }

            var partEtags = new List<PartETag>();
            for (var i = 0; i < parCount; i++)
            {
                using (var fs = File.Open(fileToUpload, FileMode.Open))
                {
                    var skipBytes = (long)partSize * i;
                    fs.Seek(skipBytes, 0);
                    var size = (partSize < fileSize - skipBytes) ? partSize : (fileSize - skipBytes);
                    var uploadPartRequest = new UploadPartRequest(bucketName, key, uploadId.UploadId)
                    {
                        InputStream = fs,
                        PartSize = size,
                        PartNumber = i + 1
                    };
                    var upLoadPartRequestResult = ossClient.UploadPart(uploadPartRequest);
                    partEtags.Add(upLoadPartRequestResult.PartETag);

                }
            }
            var completeMultipartUploadRequest = new CompleteMultipartUploadRequest(bucketName, key, uploadId.UploadId);
            foreach (var partETag in partEtags)
            {
                completeMultipartUploadRequest.PartETags.Add(partETag);
            }
            var completeResult = ossClient.CompleteMultipartUpload(completeMultipartUploadRequest);
        }
        public void CreateBucket(string bucketName)
        {
            ossClient.CreateBucket(bucketName);
        }
        public void ListObject(string bucketName)
        {
            var listObjectsRequest = new ListObjectsRequest(bucketName);
            var result = ossClient.ListObjects(listObjectsRequest);
            foreach (var summary in result.ObjectSummaries)
            {
                Console.WriteLine(summary.Key);
            }
        }
        public void CreateFolder(string bucketName, string folderName)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                //ossClient.PutObject(bucketName, folderName + @"/", ms);
            }

        }
        /// <summary>
        /// 通过GetObjectRequest 可以支持断点续传和分段下载
        /// </summary>
        /// <param name="bucketName"></param>
        /// <param name="key"></param>
        //public void GetObject(String bucketName, string key,string fileToDownload)
        //{
        //    var getObjectRequest = new GetObjectRequest(bucketName, key);
        //    getObjectRequest.SetRange(20, 100);
        //    var o = ossClient.GetObject(getObjectRequest);
        //    using (var requestStream = o.Content)
        //    {
        //        byte[] buf = new byte[1024];
        //        var fs = File.Open(fileToDownload, FileMode.OpenOrCreate);
        //        var len = 0;
        //        while ((len = requestStream.Read(buf, 0, 1024)) != 0)
        //        {
        //            fs.Write(buf, 0, len);
        //        }
        //        fs.Close();
        //    }
        //}
        public void GetObject(String bucketName, string key, string fileToDownload)
        {
            var o = ossClient.GetObject(bucketName, key);
            using (var requestStream = o.Content)
            {
                byte[] buf = new byte[1024];
                var fs = File.Open(fileToDownload, FileMode.OpenOrCreate);
                var len = 0;
                while ((len = requestStream.Read(buf, 0, 1024)) != 0)
                {
                    fs.Write(buf, 0, len);
                }
                fs.Close();
            }
        }

        public void DeleteObject(String bucketName, string key)
        {
            ossClient.DeleteObject(bucketName, key);
        }


    }
}
