/// There are 2 variants of the trianles - Left and Right.
/// Here are the Verexes convention we are going to use in this app:
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
 

To run:
	1. Open the solution vith VS 2017
	2. Start Trinagles project
	3. Rightclick JSTest project => Debug => Start New Instance

1-A: Open this url in new browser:
Signature:
	GetCoordinates/{RowCol})
Example to call:
	http://localhost:61693/Triangles/getcoordinates/a1

1-B: 
Signature:        
	GetRowCol/{x1}/{y1}/{x2}/{y2}/{x3}/{y3}")]

Example to call:
	http://localhost:61693/Triangles/getrowcol/0/10/0/0/10/0
