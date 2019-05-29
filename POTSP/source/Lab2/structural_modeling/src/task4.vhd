LIBRARY ieee;
USE ieee.std_logic_1164.all;

ENTITY sum2 IS
	port(
		A, B: in std_logic_vector(1 downto 0);
		S : out std_logic_vector(1 downto 0);
		C: out std_logic
		);
END sum2;

ARCHITECTURE struct OF sum2 IS
	COMPONENT sum1
		port(			
			A, B, Q: in std_logic;
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
	
	signal inner_carry : std_logic;
BEGIN
	first_digit: sum1 port map (
		A => A(0),
		B => B(0),
		Q => '0',
		S => S(0),
		C => inner_carry
	);
	
	second_digit: sum1 port map (
		A => A(1),
		B => B(1),
		Q => inner_carry,
		S => S(1),
		C => C
	);
END struct;

ARCHITECTURE beh OF sum2 IS
	signal inner_carry : std_logic;
BEGIN
	S(0) <= A(0) xor B(0);
	inner_carry <= A(0) and B(0);
	S(1) <= ((A(1) xor B(1)) and not inner_carry) or (not (A(1) or B(1)) and inner_carry) or (A(1) and B(1) and inner_carry);
	C <= (A(1) and B(1) and not inner_carry) or (inner_carry and (A(1) or B(1)));
END beh;