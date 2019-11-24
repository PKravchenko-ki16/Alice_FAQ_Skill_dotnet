using Alice.Model;

namespace Alice
{
    public class Response
    {
        public AliceResponse Reply(AliceRequest req, string text, bool endSession = false, ButtonModel[] buttons = null) {
                return new AliceResponse
                {
                    Response = new ResponseModel
                    {
                        Text = text,
                        Tts = text,
                        EndSession = endSession
                    },
                    Session = req.Session
                };
        }
    }
}
