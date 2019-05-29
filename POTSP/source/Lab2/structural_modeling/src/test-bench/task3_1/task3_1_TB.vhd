library ieee;
use ieee.std_logic_1164.all;

entity task3_1_tb is
end task3_1_tb;

architecture TB_ARCHITECTURE of task3_1_tb is
	component task3_1
		port(
			G_L : in STD_LOGIC;
			A : in STD_LOGIC;
			B : in STD_LOGIC;
			Y0 : out STD_LOGIC;
			Y1 : out STD_LOGIC;
			Y2 : out STD_LOGIC;
			Y3 : out STD_LOGIC );
	end component;
	
	signal G_L : STD_LOGIC := '0';
	signal A : STD_LOGIC := '0';
	signal B : STD_LOGIC := '0';
	
	signal Y0_1 : STD_LOGIC;
	signal Y1_1 : STD_LOGIC;
	signal Y2_1 : STD_LOGIC;
	signal Y3_1 : STD_LOGIC;
	
	signal Y0_2 : STD_LOGIC;
	signal Y1_2 : STD_LOGIC;
	signal Y2_2 : STD_LOGIC;
	signal Y3_2 : STD_LOGIC;
	
	signal error : STD_LOGIC;
	
	constant clock_period : time := 10 ns; 
begin
	behavioral : entity task3_1(beh)
	port map (
		G_L => G_L,
		A => A,
		B => B,
		Y0 => Y0_1,
		Y1 => Y1_1,
		Y2 => Y2_1,
		Y3 => Y3_1
		);
	
	structural : entity task3_1(struct)
	port map (
		G_L => G_L,
		A => A,
		B => B,
		Y0 => Y0_2,
		Y1 => Y1_2,
		Y2 => Y2_2,
		Y3 => Y3_2
		);
	
	G_L <= not G_L after clock_period;
	A <= not A after clock_period * 2;
	B <= not B after clock_period * 4;
	
	error <= (Y0_2 xor Y0_1) or (Y1_2 xor Y1_1) or (Y2_2 xor Y2_1) or (Y3_2 xor Y3_2);
end TB_ARCHITECTURE;

