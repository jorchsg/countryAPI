using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class RecordNotFoundException: Exception
{
    public override string Message { get; }

    public RecordNotFoundException(string className, string id)
    {
        Message = "Could not find " + className + "with id" + id;
    }
}

