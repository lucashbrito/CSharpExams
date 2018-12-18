using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    public class JsonClass
    {
        private string json = @"{'People':
                                    {'Person': [
                                                {'firstName': 'John','lastName': 'Doe', 'ContactDetails': { 'EmailAddress': 'john@unknown.com' }},
                                                {'firstName': 'Jane','lastName': 'Doe','ContactDetails': {'EmailAddress': 'jane@unknown.com','PhoneNumber': '001122334455'}}]}}";

    }
}
