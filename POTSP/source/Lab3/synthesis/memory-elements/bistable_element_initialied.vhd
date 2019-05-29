library IEEE;
use IEEE.STD_LOGIC_1164.all;

library IEEE;
use IEEE.STD_LOGIC_1164.all;

entity BistableElementInitialized is
	port(
		Q : out STD_LOGIC;
		nQ : out STD_LOGIC
		);
end BistableElementInitialized;

architecture initialized of BistableElementInitialized is
	component inv
		port (
			a: in std_logic;
			nA: out std_logic
			);
	end component;
	signal t1: std_logic;  
	signal t2: std_logic := '0';
begin	
	U1: inv port map (a => t2, nA => t1);
	U2: inv port map (a => t1, nA => Q);	  
	nQ <= t1;
end initialized;