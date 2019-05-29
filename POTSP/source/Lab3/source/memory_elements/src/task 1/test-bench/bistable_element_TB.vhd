library ieee;
use ieee.std_logic_1164.all;

entity BistableElement_tb is
end BistableElement_tb;

architecture TB_ARCHITECTURE of BistableElement_tb is	
	component BistableElement
		port(
			Q : out STD_LOGIC;
			nQ : out STD_LOGIC);
	end component;
		
	signal initialized_Q : STD_LOGIC;
	signal initialized_nQ : STD_LOGIC;
	
	signal uninitialized_Q : STD_LOGIC;
	signal uninitizlied_nQ : STD_LOGIC;
begin	
	initialized : entity BistableElement(initialized)
	port map (
		Q => initialized_Q,
		nQ => initialized_nQ
		);	 
		
	uninitialized : entity BistableElement(uninitialized)
	port map (
		Q => uninitialized_Q,
		nQ => uninitizlied_nQ
		);	
end TB_ARCHITECTURE;
