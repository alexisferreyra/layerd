function $$main(mainFunction) {
    window.onload = function() {
        try
        {
            if (mainFunction !== undefined && mainFunction instanceof Function)
            {
                mainFunction();
            }
            else
            {
                console.log("Main function not provided.");
            }
        }
        catch(e)
        {
            console.log("Exception: " + e.toString());
        }
    };
}

Zoe = {};

Zoe.createNamespace = function(name) {
	if(window[name] === undefined){
		window[name] = new Object();
	}
};

Zoe.truncate = function(number)
{
    return number < 0 ? Math.ceil(number) : Math.floor(number);
};
