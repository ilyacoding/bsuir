library ieee;
use ieee.std_logic_1164.all;

entity tff_tb is
end tff_tb;

architecture TB_ARCHITECTURE of tff_tb is
	component tff
	port(
		T : in std_logic;
		CLK : in std_logic;
		CLR : in std_logic;
		Q : out std_logic
		);
	end component;

	signal T : std_logic := '0';
	signal CLK : std_logic := '0';
	signal CLR : std_logic := '1';
	
	signal Q : std_logic;
	
	constant clock : integer := 10;
	constant clock_period : time := clock * 1 ns;
	constant clr_period : time := ((clock * 10) - (clock / 2)) * 1 ns;

begin
	UUT : tff
		port map (
			T => T,			
			Q => Q,
			CLK => CLK,
			CLR => CLR
		);
		
	CLK <= not CLK after clock_period;
	T <= not T after clock_period * 8;
	CLR <= '1' after clr_period when CLR = '0' else '0' after clock_period;

end TB_ARCHITECTURE;


