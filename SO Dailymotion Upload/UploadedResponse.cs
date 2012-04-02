namespace SO_Dailymotion_Upload
{
    public class UploadedResponse
    {
        public string id { get; set; }

        public override string ToString()
        {
            return "Video available now at:\n\nhttp://www.dailymotion.com/video/" + id;
        }
    }
}
