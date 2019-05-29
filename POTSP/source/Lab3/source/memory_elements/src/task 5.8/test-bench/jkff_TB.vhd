library ieee;
use ieee.std_logic_1164.all;

entity jkff_tb is
end jkff_tb;

architecture TB_ARCHITECTURE of jkff_tb is
	component jkff
	port(
		J : in STD_LOGIC;
		K : in STD_LOGIC;
		CLK : in STD_LOGIC;
		Q : out STD_LOGIC );
	end component;

	signal J : STD_LOGIC := '0';
	signal K : STD_LOGIC := '0';
	signal CLK : STD_LOGIC := '0';
	
	signal Q : STD_LOGIC;
	
	constant clock_period : time := 10 ns;
begin
	UUT : entity work.jkff(jkff)
		port map (
			J => J,
			K => K,
			CLK => CLK,
			Q => Q
		);
	
	CLK <= not CLK after clock_period;
	J <= not J after clock_period * 8;
	K <= not K after clock_period * 16;

end TB_ARCHITECTURE;

