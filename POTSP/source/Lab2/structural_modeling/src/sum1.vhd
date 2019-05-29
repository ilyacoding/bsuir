LIBRARY ieee;
USE ieee.std_logic_1164.all;

ENTITY sum1 IS
	port(
		A, B, Q: in std_logic;
		S,
		C: out std_logic
		);
END sum1;

ARCHITECTURE struct OF SUM IS
	COMPONENT HALF_SUM
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
	U1: HALF_SUM port map(A=>A, B=>B, S=>A_B_sum, C=>A_B_carry);
	U2: HALF_SUM port map(A=>Q, B=>A_B_sum, S=>S, P=>A_B_Q_carry);
	U3: OR2 port map(A=>A_B_Q_carry, B=>A_B_carry, Z=>C);
END struct;