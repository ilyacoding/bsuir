LIBRARY ieee;
USE ieee.std_logic_1164.all;

ENTITY mux2x2 IS      					
	port(        					
		A, B: in std_logic_vector(0 to 1);
		S: in std_logic;
		Z: out std_logic_vector(0 to 1)
		); 
END mux2x2;
-- 
ARCHITECTURE beh OF mux2x2 IS
BEGIN
	Z<= A when S='0' else B;
END beh;