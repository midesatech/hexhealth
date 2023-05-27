namespace MDT.SupabaseDb
{
    public class Context
    {
        private Supabase.Client client;


        public Context(string url, string apiKey) { 

            client = new Supabase.Client(url, apiKey);
            Init();            
        }

        private async void Init() {
           await client.InitializeAsync();
        }

    }
}