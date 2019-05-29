library ieee;
use ieee.std_logic_1164.all;

entity FDCPE_TB is
end FDCPE_TB;

architecture TB_ARCHITECTURE of FDCPE_TB is
	component FDCPE
		port(
			CLR : in STD_LOGIC;
			PRE : in STD_LOGIC;
			D : in STD_LOGIC;
			E : in STD_LOGIC;
			CLK : in STD_LOGIC;
			Q : out STD_LOGIC
			);
	end component;
	
	signal CLR : STD_LOGIC := '0';
	signal PRE : STD_LOGIC := '0';
	signal D : STD_LOGIC := '0';
	signal E : STD_LOGIC := '0';
	signal CLK : STD_LOGIC := '0';
	
	signal Q : STD_LOGIC;	
	
	constant clock : integer := 10;
	constant clock_period : time := clock * 1 ns;
	constant preset_period : time := ((clock * 20) - (clock / 2)) * 1 ns;
	constant clr_period : time := ((clock * 40) - (clock / 2)) * 1 ns;
begin
	UUT : FDCPE
	port map (
		CLR => CLR,
		PRE => PRE,
		D => D,
		E => E,
		CLK => CLK,
		Q => Q
		);
		
	CLK <= not CLK after clock_period;
	D <= not D after clock_period * 4;
	E <= not E after clock_period * 8;
	PRE <= '1' after preset_period when PRE = '0' else '0' after clock_period / 2;
	CLR <= '1' after clr_period when CLR = '0' else '0' after clock_period / 2;
	
end TB_ARCHITECTURE;

