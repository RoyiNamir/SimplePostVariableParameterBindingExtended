SimplePostVariableParameterBindingExtended
==========================================

Why do I need it ? 

Consider this code : 


    [HttpPost]
    [AllowAnonymous]
    [ActionName("Login")]
    public HttpResponseMessage Login(int MasterEntity, string username, string password, string userAgent)
    {
      //...
    }
    
This method gets its param from the body.

In WebAPI you can't get (nativly) multiple form parameters `[frombody]`.

Rick started doing it :
http://weblog.west-wind.com/posts/2012/Sep/11/Passing-multiple-simple-POST-Values-to-ASPNET-Web-API

But it didnt support nullables types.

So  you couldn't do : 

   public HttpResponseMessage Login(int? MyInt,int A)
   { 
   //...
   }
   
Also the code didn't support if a person suddnley  sends JSON. there were no code for this : 


    // only read if there's content and it's form data
    if (contentType == null || contentType.MediaType != "application/x-www-form-urlencoded")
    {
        // Nope no data
        result = null;
    }
    else
    {
        // parsing the string like firstname=Hongmei&lastname=ASDASD            
        result = request.Content.ReadAsFormDataAsync().Result;
    }
  
  
  
So now you can send JSON to the controller both in `application/x-form-urlencoded` (`a=1&b=2&c=`) and also via `application/json`
`{"a":1,"b":2}` or `{"a":1,"b":2,"c":null}`

webAPI can work with JSON (obviously) , but you need  : 

   Login(NyLoginParams mlp)
   {
    /...
   }


So my class also support JSON & Nullables!






