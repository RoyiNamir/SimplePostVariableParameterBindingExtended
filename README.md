SimplePostVariableParameterBindingExtended
==========================================

Why do we need it? 

Consider this code : 

    [HttpPost]
	[MultiParameterSupport]
    public HttpResponseMessage Login(int MasterEntity, string username, string password, string userAgent)
    {
		//...logics...
    }
    
This method gets its parameters from the body via POST.

In WebAPI you can't(!) get (nativly) multiple form parameters  via `[frombody]`.
Rick started doing it : http://weblog.west-wind.com/posts/2012/Sep/11/Passing-multiple-simple-POST-Values-to-ASPNET-Web-API

But it didn't support nullables types.
So you couldn't do : 
   
    public HttpResponseMessage Login(int? MyInt,int A)
    { 
		//...logics...
    }
   
Also, it didn't support a situation where a person sends JSON. there was no code for this situation: 

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
  
So now you can(!) send JSON to the controller both via  `application/x-form-urlencoded` (`a=1&b=2&c=`) and also via `application/json`
`{"a":1,"b":2}` or `{"a":1,"b":2,"c":null}`


NB
webAPI can work with JSON (obviously) , but you need: 

    Login(NyLoginParams mlp)
    {
		//...logics...
    }

Assuming you need to expose Many existsing services which doesnt has `MyMethodParams` class - you'll need this code .










