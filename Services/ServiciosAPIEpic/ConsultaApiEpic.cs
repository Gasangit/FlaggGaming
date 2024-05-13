using FlaggGaming.Model.apiSteamJuego;
using System;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using System.Diagnostics.Metrics;
using System.Globalization;

namespace FlaggGaming.Services.APIEpic
{
    public class ConsultaApiEpic
    {    
        
        public static string armarConsultaEpic(string keyword, int cantidad, string sortBy, string sortDir, int start)
        {
        //agregar seguridad filtrando lo ingresado para evitar inyecciones
            string consulta = $"https://graphql.epicgames.com/graphql?query=query searchStoreQuery(\r\n  $allowCountries: String\r\n  $category: String\r\n  $namespace: String\r\n  $itemNs: String\r\n  $sortBy: String = \"{sortBy}\"\r\n  $sortDir: String = \"{sortDir}\"\r\n  $start: Int = {start}\r\n  $tag: String\r\n  $releaseDate: String\r\n  $withPrice: Boolean = true\r\n) {{\r\n  Catalog {{\r\n    searchStore(\r\n      allowCountries: $allowCountries\r\n      category: $category\r\n      count: {cantidad}\r\ncountry: \"AR\"\r\n      keywords: \"{keyword}\"\r\n      namespace: $namespace\r\n      itemNs: $itemNs\r\n      sortBy: $sortBy\r\n      sortDir: $sortDir\r\n      releaseDate: $releaseDate\r\n      start: $start\r\n      tag: $tag\r\n    ) {{\r\n      elements {{\r\n        title\r\n        description\r\n        keyImages {{\r\n          type\r\n          url\r\n        }}\r\nseller {{\r\n          name\r\n}}\r\ncategories {{\r\n          path\r\n}}\r\nprice(country: \"AR\") @include(if: $withPrice) {{\r\n          totalPrice {{\r\n            fmtPrice(locale: \"en-US\") {{\r\n    discountPrice\r\n            }}\r\n          }}\r\n        }}\r\n\r\n      }}\r\n    }}\r\n  }}\r\n}}";
            return consulta;

        }
    }
}


