library ieee;
use ieee.std_logic_1164.all;

entity d_flipflop_TB is
end d_flipflop_TB;

architecture TB_ARCHITECTURE of d_flipflop_TB is
	component D_FlipFlop
	port(
		D : in std_logic;
		CLK : in std_logic;
		Q : out std_logic );
	end component;


	signal D : std_logic := '0';
	signal CLK : std_logic := '0';

	signal Q : std_logic;
	
	constant clock : time := 10 ns;
	constant data_period : time := clock * 4;
begin
	UUT : D_FlipFlop
		port map (
			D => D,
			CLK => CLK,
			Q => Q
		);	  
	
	D <= not D after data_period;
	CLK <= not CLK after clock;
	
end TB_ARCHITECTURE;

