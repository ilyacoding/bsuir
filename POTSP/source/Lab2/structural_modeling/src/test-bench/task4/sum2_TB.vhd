library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;  
use IEEE.STD_LOGIC_ARITH.ALL;
use IEEE.STD_LOGIC_UNSIGNED.ALL;


entity sum2_tb is
end sum2_tb;


architecture TB_ARCHITECTURE of sum2_tb is

	component sum2
	port(
		A : in STD_LOGIC_VECTOR(1 downto 0);
		B : in STD_LOGIC_VECTOR(1 downto 0);
		S : out STD_LOGIC_VECTOR(1 downto 0);
		C : out STD_LOGIC );
	end component;

	signal A : STD_LOGIC_VECTOR(1 downto 0) := "00";
	signal B : STD_LOGIC_VECTOR(1 downto 0) := "00";
	
	signal S_1 : STD_LOGIC_VECTOR(1 downto 0);
	signal C_1 : STD_LOGIC;
	
	signal S_2 : STD_LOGIC_VECTOR(1 downto 0);
	signal C_2 : STD_LOGIC;
	
	signal error : std_logic;
begin
	behavioral : entity sum2(beh)
		port map (
			A => A,
			B => B,
			S => S_1,
			C => C_1
		);	 
		
	structural : entity sum2(struct)
		port map (
			A => A,
			B => B,
			S => S_2,
			C => C_2
		);				
		
	error <= '0' when S_1 = S_2 and C_1 = C_2 else '1';											 
	
	A <= A + "1" after 10 ns;
	B <= B + "1" after 40 ns;
		
end TB_ARCHITECTURE;

