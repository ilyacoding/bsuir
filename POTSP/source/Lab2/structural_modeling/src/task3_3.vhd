library ieee;
use ieee.std_logic_1164.all;
-- v. 2
entity task3_3 is
   port(        					
      X, Y, Z: in std_logic; 
      F: out std_logic
   ); 
end task3_3;

architecture struct of task3_3 is

component and3
	port(        					
		A, B, C: in std_logic; 
		R: out std_logic
	);	
end component;

component and2
	port(        					
		A, B: in std_logic; 
		R: out std_logic
	);	
end component;

component or3
	port(        					
		A, B, C: in std_logic; 
		R: out std_logic
	);	
end component;

component inv
	port(
		A: in std_logic;
		nA: out std_logic
	);
end component;

signal nX, nY, nZ, X_Z, nY_Z, and_nX_Y_nZ: std_logic;
begin						  
	U1: inv port map(X, nX);
	U2: inv port map(Y, nY);
	U3: inv port map(Z, nZ);
	U4: and2 port map(X, Z, X_Z);
	U5: and2 port map(nY, Z, nY_Z);
	U6: and3 port map(nX, Y, nZ, and_nX_Y_nZ);
	U7: or3 port map(X_Z, nY_Z, and_nX_Y_nZ, F);
end struct;

architecture beh of task3_3 is
begin
	F <= (X and Z) or ((not Y) and Z) or ((not X) and Y and (not Z));
end beh;