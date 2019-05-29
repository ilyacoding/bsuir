LIBRARY ieee;
USE ieee.std_logic_1164.all;

ENTITY or4 IS      					
	port(        					
		A1, A2, A3, A4: in std_logic; 
		Z: out std_logic
		); 
END or4;
-- 
ARCHITECTURE beh OF or4 IS
BEGIN 
	Z<=A1 or A2 or A3 or A4;
END beh;