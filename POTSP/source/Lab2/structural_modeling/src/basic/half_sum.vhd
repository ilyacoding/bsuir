LIBRARY ieee;
USE ieee.std_logic_1164.all;

ENTITY half_sum IS
	port(
		A, B: in std_logic;
		S: out std_logic;
		C: out std_logic
		);
END half_sum;

ARCHITECTURE struct OF half_sum IS	
	COMPONENT xor2	  
		port(
			A, B: in std_logic;
			R: out std_logic
			);
	END COMPONENT;
	COMPONENT and2	  
		port(
			A, B: in std_logic;
			R: out std_logic
			);
	END COMPONENT;
BEGIN
	U1: xor2 port map(A=>A, B=>B, R=>S);
	U2: and2 port map (A=>A, B=>B, R=>C);
END struct;													 								