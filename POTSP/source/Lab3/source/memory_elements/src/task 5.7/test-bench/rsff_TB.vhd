library ieee;
use ieee.std_logic_1164.all;

entity rsff_tb is
end rsff_tb;

architecture TB_ARCHITECTURE of rsff_tb is
	component rsff
		port(
			R : in STD_LOGIC;
			S : in STD_LOGIC;
			CLK : in STD_LOGIC;
			Q : out STD_LOGIC );
	end component;
	
	signal R : STD_LOGIC := '0';
	signal S : STD_LOGIC := '0';
	signal CLK : STD_LOGIC := '0';
	
	signal Q : STD_LOGIC;	   
	
	constant clock_period : time := 10 ns;
begin
	UUT : rsff
	port map (
		R => R,
		S => S,
		CLK => CLK,
		Q => Q
		);
	
	CLK <= not CLK after clock_period;
	S <= not S after clock_period * 4;
	R <= not R after clock_period * 8;
	
end TB_ARCHITECTURE;

