using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Triangles.Model;

namespace Tringles.Controllers
{
/// There are 2 variants of trianles - Left and Right.
/// Here are the Verexes convention we are going to use here:
/// 
/// Left Triange:
/// 
///     V2
/// 
///     V1    V3
/// 
/// Right Triangle:
/// 
///     V2    V1
/// 
///           V3
/// 
/// So, using this schems the V2 and V3 are always going to 
/// be the same for Left and Right triangles and we will 
/// have to change the V1 Vertex only!
/// 

    [Route("[controller]")]
    public class TrianglesController : Controller
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="StrNum"></param>
        /// <returns></returns>
        [HttpGet("[action]/{RowCol}")]
        public async Task<JsonResult> GetCoordinates(string RowCol)
        {
            // http://localhost:61693/Triangles/getcoordinates/a1

            Vertex V1 = new Vertex();
            Vertex V2 = new Vertex();
            Vertex V3 = new Vertex();

            try
            {
                // Getting row from first Char in the input string
                int Row = RowCol.ToUpper()[0] - 'A' + 1;
                // If string is not formatted well it will rise exaption here and will be cought by Catch block
                int Col = int.Parse(RowCol.Substring(1));
                // Calculating if it is Left or Right Triangle given
                bool isLeftTria = ((Col & 1) == 1);

                // Since each column has 2 triangles the actual coplumn number has to be ajusted like this:
                Col = (Col + (isLeftTria ? 1 : 0)) / 2;

                // checking if it is a Left Triangle by using bitwise operator
                if (isLeftTria)
                {
                    V1.X = (Col - 1) * 10;
                    V1.Y = Row * 10;
                }
                else
                {
                    V1.X = Col * 10;
                    V1.Y = (Row - 1) * 10;
                }

                V2.X = (Col - 1) * 10;
                V2.Y = (Row - 1) * 10;

                V3.X = Col * 10;
                V3.Y = Row * 10;
            }
            catch (Exception e)
            {
                return new JsonResult(new { e.Message });
            }

            return new JsonResult(new { V1, V2, V3 });
        }


        /// <summary>
        /// See coments for this class on a top of this file to understand 
        /// the difference in coordinates between Left and Right triangles
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <returns></returns>
        [HttpGet("[action]/{x1}/{y1}/{x2}/{y2}/{x3}/{y3}")]
        public async Task<JsonResult> GetRowCol(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            // http://localhost:61693/Triangles/getrowcol/0/10/0/0/10/0

            try
            {
                // On a left triange V1 and V2 have the same X:
                bool    isLeftTria  = (x1 == x2);
                // Getting Column
                int     Col         = (x2 / 10) * 2 + (isLeftTria ? 0 : 1) + 1;
                // Since V2 is the same for Left and Right Triangle, we use it for calculation in both cases
                char    Row         = (char) ('A' + y2/10);

                return new JsonResult(new { Row, Col });
            }
            catch (Exception e)
            {
                return new JsonResult(new { e.Message });
            }
        }
    }
}