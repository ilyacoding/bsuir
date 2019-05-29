LIBRARY ieee;
USE ieee.std_logic_1164.all;

ENTITY fun IS      					
	port(        					
		in1, in2, in3: in std_logic; 
		Q: out std_logic
		); 
END fun;
-- 
ARCHITECTURE beh OF fun IS
BEGIN 
	Q<=(in1 and in2) or (in3 and not in2);
END beh;