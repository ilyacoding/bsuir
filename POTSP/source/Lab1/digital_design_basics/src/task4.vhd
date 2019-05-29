LIBRARY ieee;
USE ieee.std_logic_1164.all;

ENTITY fun_not IS      					
	port(        					
		in1, in2, in3: in std_logic; 
		Q, nQ: out std_logic
		); 
END fun_not;
-- 
ARCHITECTURE beh OF fun_not IS
	signal result: std_logic;
BEGIN
	result<=(in1 and in2) or (in3 and not in2);
	Q<=result;
	nQ<=not result;
END beh;