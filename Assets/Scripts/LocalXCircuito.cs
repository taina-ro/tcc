using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalXCircuito
{
    public int Local_ID { get; set; }
    public int Circuito_ID { get; set; }

    public LocalXCircuito(int local_ID, int circuito_ID) 
    { 
        Local_ID = local_ID;
        Circuito_ID = circuito_ID;
    }

}
