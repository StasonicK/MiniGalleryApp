using Demo.Scripts;
using Retrofit.Methods;
using Retrofit.Parameters;
using UniRx;

public interface GalleryApi
{
    [Get("/get")]
    IObservable<HttpBinResponse> Get(
        [Query("query1")] string arg1,
        [Query("query2")] string arg2
    );
}