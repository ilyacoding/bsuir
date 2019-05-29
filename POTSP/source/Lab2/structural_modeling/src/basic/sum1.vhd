LIBRARY ieee;
USE ieee.std_logic_1164.all;

ENTITY sum1 IS
	port(
		A, B, Q: in std_logic;
		S,
		C: out std_logic
		);
END sum1;

ARCHITECTURE struct OF sum1 IS
	COMPONENT half_sum
		port(
			A, B: in std_logic;
			S,
			C: out std_logic
			);
	END COMPONENT;
	COMPONENT OR2
		port(
			A, B: in std_logic;
			R: out std_logic
			);
	END COMPONENT;
	signal A_B_sum, A_B_carry, A_B_Q_carry: std_logic;
BEGIN
	U1: half_sum port map(A=>A, B=>B, S=>A_B_sum, C=>A_B_carry);
	U2: half_sum port map(A=>Q, B=>A_B_sum, S=>S, C=>A_B_Q_carry);
	U3: or2 port map(A=>A_B_Q_carry, B=>A_B_carry, R=>C);
END struct;