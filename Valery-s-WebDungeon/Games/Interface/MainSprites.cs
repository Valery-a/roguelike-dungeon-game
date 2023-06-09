﻿//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

using System;
using System.Threading.Tasks;

namespace Valery_s_Dungeon
{
    public class MainSprites
    {
        public const string Value1 =
        "                       PICK YOUR PLAYER FROM THE LIST BELOW: (if you have one) ( ͡° ͜ʖ ͡°) ";

        //credits to Tua Xiong for the art where god fights vs a demon
        public const string GodVsEvil = @"
             ///~`     |\\_              h        =\\\\         . .          j  
            ,  |='  ,))\_| ~-_           h         _)  \      _/_/|          j  
           / ,' ,;((((((    ~ \          h        `~~~\-~-_ /~ (_/\          j  
         /' -~/~)))))))'\_   _/'         h             \_  /'  D   |         j  
        ((((((( ~-/ ~-/                  h        ~-;  /    \--_             j  
         ~~--|   ))''    ')  `           h                 `~~\_    \   )    j  
             :        (_  ~\           , h                   /~~-     ./     j  
              \        \_   )--__  /(_/) h                  |    )    )|     j  
    ___       |_     \__/~-__ ~~   ,'    h  /,_;,   __--(   _/      |        j  
  //~~\`\    /' ~~~----|     ~~~~~~~~'   h     \-  ((~~    __-~        |     j  
((()   `\`\_(_ _-~~-\                    h  ``~~ ~~~~~~   \_      /          j  
 )))     ~----'   /      \               h                    )       )      j  
  (         ;`~--'        :              h                  _-    ,;;(       j  
            |    `\       |              h               _-~    ,;;;;)       j  
            |    /'`\     ;              h            _-~          _/        j  
           /~   /    |    )              h           /;;;''  ,;;:-~          j  
          |    /     / | /               h          |;;'   ,''               j  
          /   /     |  \\|               h          |   ,;(                  j  
        _/  /'       \  \_)              h     .---__\_    \,--._______      j  
       ( )|'         (~-_|               h    (;;'  ;;;~~~/' `;;|  `;;;\     j  
        ) `\_         |-_;;--__          h     ~~~----__/'    /'_______/     j  
        `----'       (   `~--_ ~~~;;-----h-------~~~~~ ;;;'_/'               j  
                     `~~~Tua-Xiong-----..h..___;;;____---~~                  j
";

        public const string WelcomeTxT = @"
                                                                                   
⟶⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟵                                                                            
                                                                                                            
                                                                                                                  
                                                                                                                    
___________ /\   /\ ____________   __________  _____  ___________ ____________       _____  _____ _______________________ 
\__    ___//  |_|  \\_   _____/   \_   _____/ /  _  \ \__    ___//   _____/   |     /  _  \ \__  |   |_   _____/______   \
  |    |  /         \|    __)_      |  ___)  /  /_\  \  |    |   \_____  \|   |    /  /_\  \ /   |   ||    __)_ |       _/
  |    |  \    _    /|        \     |  \__  /    |    \ |    |   /        \   |___/    |    \\____   ||        \|    |   \
  |____|   \  | |  //_______  /    /___  /  \____|__  / |____|  /_______  /______ \____|__  // ______|_______  /|____|_  /
            \/   \/         \/         \/           \/                  \/       \/       \/ \/              \/        \/ 

                                                                                                        
                                                                                                        

⟶⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟷⟵
                                                                                                           
                                                                                                          
";

        //credits to LGB for the art
        public const string HavenGodGrave = @"
               _.----------------------------._
           _.-'          '-        .           '-._
         .'      _|   .    . - .        ._         '.
      _.'    '           .'     '.               _| |
     /  _|        _|    ''       ''  |_     '    .  '.
    |      . -- .      ''         ''      . -- .     |
   .'    .'      '.   -||         ||    .'      '.   '.
   | '  ''        ''   ||   .-.   ||_  ''        ''   |
   '.  ''          ''  ||   | |   ||  ''          ''  |
    | -||          ||- '____|!|____' -||          ||- |
    |  ||          ||  |____-+-____|  ||          ||  '.
   .' -||          ||_ ||   |!|   ||  ||          ||  _|
   |_.-||          ||  ||   | |   || _||          ||-._|
_.-' |_||          ||  ||   | |   ||  ||          ||_| '-._
_| |_  |:;;.,::;,.';|--|:;;.| |,.';|--|:;;.,::;,.';|     |_
         :;;.,::;,.';   :;;.| |,.';    :;;.,::;,.';  _|   -'
   |_                       | |                         |_.
 _      _|                __|_|__              |_     _
|________________________/__LGB__\___________________|______
,:.,:.,:.,:.,:.,:.,:.,:.,:.,:.,:.,:.,:.,:.,:.,:.,:.,:.,:.,:.
------------------------------------------------------------
";

        //credits to Alex Pelton for the demon with horns
        //credits to xop / @athena.mit.edu / James Goodwin for the flying demon dragon                                    


        //credits to jro for the angle
        public const string Angle1 = @"
 (  (   (         `.                  ||            .-'   .'  `.   )` - .)
 ((  .-'   .-'  `.  `-.               ||          .'   .'     )  ) - . )  )
  (  ( .-'       `-.   \            __/\__       / .'     `-.   `. )     )
   `. ( _.-'         `. `.          _(  |       :     `-.       )   `-.  )
    (   (   .'.-'         `.       /  ) /     .'  .'`.     `-.     ) _.-'
    (.-' (      .-'    `.   `.    | ,'| |   .' .'                )  )
     (     (     .'        `. `.,' /  |  \.'  : `-._`-.  `-.  `.)`.)
      `-._  (       .'  .     ,'  /    \  \ .'               )`.  )
          (      (       .'  /   ,-""""-./\  \ `.  `-.  )   )`-._.-'
           `-.      .'       |  / __.. `|  /               .-'
              \   .'     .'  | | /_  _\/  / `-. `.    ) .-'
               `-._.'        | \ )    (|  |            /
                   `-._   ,; |.' \    /   |   ` .  _.-'
                       """"-._ /   )`--'|   |  `._.-'
                            /   /`-..-'  /_..-'
                           ;  _/        |
                            ,'          `.
                            |            |
                            `.__.-' '.__.'
                               `.       |
                                 \       `.
                                  |         .
                                  |          \
                                  |           .
                                 ,'           |
                                .'            |
                               ,'             |
                              .'             /
                              |              /
                              |             |
                              |             /
                             |             |
                             |             |
                            /               \
                           /    /            |
                          /           .:     |
                         /    .      .:      |
                        /    .:      .:     ,'
                      ,'    .:      .::__.-|
                     -..__   : __jro.-' \  |
                       /  |''''         /  (
                     .'  ,'             \_  `.
                     `..'                 `.__;

";

        //credits to Lukasz Dabrowski for the Angle2 art AKA luk
        public const string Angle2 = @"
              ;M;.           ,      ,           ;SMM;
             ;;Mm;         ,;  ____  ;,         ;SMM;
            ;;;MM;        ; (.MMMMMM.) ;       ,SSMM;;
          ,;;;mMp'        l  ';mmmm;/  j       SSSMM;;
        .;;;;;MM;         .\,.mmSSSm,,/,      ,SSSMM;;;
       ;;;;;;mMM;        .;MMmSSSSSSSmMm;     ;MSSMM;;;;
      ;;;;;;mMSM;     ,_ ;MMmS;;;;;;mmmM;  -,;MMMMMMm;;;;
     ;;;;;;;MMSMM;     \""*;M;( ( '') );m;*""/ ;MMMMMM;;;;;,
    .;;;;;;mMMSMM;      \(@;! _     _ !;@)/ ;MMMMMMMM;;;;;,
    ;;;;;;;MMSSSM;       ;,;.*^*> <*^*.;m; ;MMMMMMMMM;;;;;;,
   .;;;;;;;MMSSSMM;     ;Mm;           ;M;,MMMMMMMMMMm;;;;;;.
   ;;;;;;;mmMSSSMMMM,   ;Mm;,   '-    ,;M;MMMMMMMSMMMMm;;;;;;;
   ;;;;;;;MMMSSSMMMMMMMm;Mm;;,       ,;SmM;MMMMMMSSMMMM;;;;;;;;
   ;;'"";;;MMMSSSSMMMMMM;MMmS;;,  ""  ,;SmMM;MMMMMMSSMMMM;;;;;;;;.
   !   ;;;MMMSSSSSMMMMM;MMMmSS;;._.;;SSmMM;MMMMMMSSMMMM;;;;;;;;;
       ;;;;*MSSSSSSMMMP;Mm*""'q;'   `;p*""*M;MMMMMSSSSMMM;;;;;;;;;
       ';;;  ;SS*SSM*M;M;'     `-.        ;;MMMMSSSSSMM;;;;;;;;;,
        ;;;. ;P  `q; qMM.                 ';MMMMSSSSSMp' ';;;;;;;
        ;;;; ',    ; .mm!     \.   `.   /  ;MMM' `qSS'    ';;;;;;
        ';;;       ' mmS';     ;     ,  `. ;'M'   `S       ';;;;;
         `;;.        mS;;`;    ;     ;    ;M,!     '        ';;;;
          ';;       .mS;;, ;   '.    ;    ;MM;                ;;;;
           ';;      MMmS;; `,   ;._.' -_.'MM;                 ;;;
            `;;     MMmS;;; ;   ;      ;  MM;                 ;;;
              `'.   'MMmS;; `;) ',    .' ,M;'                 ;;;
                 \    '' ''; ;   ;    ;  ;'                   ;;
                  ;        ; `,  ;    ;  ;                   ;;
                           |. ;  ; (. ;  ;      _.-.         ;;
              .-----..__  /   ;  ;   ;' ;\  _.-"" .- `.      ;;
            ;' ___      `*;   `; ';  ;  ; ;'  .-'    :      ;
            ;     """"""*-.   `.  ;  ;  ;  ; ' ,'      /       |
            ',          `-_    (.--',`--'..'      .'        ',
              `-_          `*-._'.\\\;||\\)     ,'
                 `""*-._        ""*`-ll_ll'l    ,'
                    ,==;*-._           ""-.  .'
                 _-'    ""*-=`*;-._        ;'
               .""            ;'  ;""*-.    `
               ;   _LD_      ;//'     ""-   `,
               `+   .-/                 "".\\;
                 `*"" /                    ""'

";


        //credits to jgs for the priest art
        public const string Priest = @"

 .  _ o  .                                                     .  _ o  .
 .   /\  .                              .---.                  .   /\  .
 .  | \  .                             /.'""'.\                .  | \  .
 .       .                             \\   ||                 .       .
 .       .                     /^\    ,_),-','                 .       .
 .  __\o .                   .'_|_'.     ()`                   .  __\o .
 . /) |  .                  <   |   >    ||                    . /) |  .
 .       .                   \_____/     ||                    .       .
 . __|   .                   {/a a\}     ||                    . __|   .
 .   \o  .                  {/-.^.-\}   (_|                    .    \o .
 .   ( \ .                 .'{  `  }'-._/|;\                   .   ( \ .
 .       .                /  {     }  /; || |                  .       .
 .  \ /  .               /`'-{     }-';  || |                  .  \ /  .
 .   |   .              ; `'=|{   }|=' _/|| |                  .   |   .
 .  /o\  .              |   \| |~| |  |/ || |                  .  /o\  .
 .       .              |\   \ | | |  ;  || |                  .       .
 .   |__ .              | \   ||=| |=<\  || |                  .   |__ .
 . o/    .              | /\_/\| | |  \`-||_/                  . o/    .
 ./ )    .              '-| `;'| | |  |  ||                    ./ )    .
 .       .                |  |+| |+|  |  ||                    .       .
 .       .                |  | jgs |  |  ||                    .       .
 . o/__  .                |  """""" ""|  ||                    . o/__  .
 .  | (\ .                |           |  ||                    . |  (\ .
 .       .                |_ _ _ _ _ _|  ||                    .       .
 .  o _  .                |,;,;,;,;,;,|  ||                    .  o _  .
 .  /\   .                `|||||||||||`  ||                    .  /\   .
 .  / |  .                 |||||||||||   ||                    .  / |  .
 .       .                                                     .       .
 .       .                   NOT READY                         .       .
";

        //-nabis- skeleton axe
        public const string SkeletonAndZombie = @"                                                                       
                              _.--""""-._
  .                         .""         "".
 / \    ,^.         /(     Y             |      )\
/   `---. |--'\    (  \__..'--   -   -- -'""""-.-'  )
|        :|    `>   '.     l_..-------.._l      .'
|      __l;__ .'      ""-.__.||_.-'v'-._||`""----""
 \  .-' | |  `              l._       _.'
  \/    | |                   l`^^'^^'j
        | |                _   \_____/     _
        j |               l `--__)-'(__.--' |
        | |               | /`---``-----'""1 |  ,-----.
        | |               )/  `--' '---'   \'-'  ___  `-.
        | |              //  `-'  '`----'  /  ,-'   I`.  \
      _ L |_            //  `-.-.'`-----' /  /  |   |  `. \
     '._' / \         _/(   `/   )- ---' ;  /__.J   L.__.\ :
      `._;/7(-.......'  /        ) (     |  |   nabis    | |
      `._;l _'--------_/        )-'/     :  |___.    _._./ ;
        | |                 .__ )-'\  __  \  \  I   1   / /
        `-'                /   `-\-(-'   \ \  `.|   | ,' /
                           \__  `-'    __/  `-. `---'',-'
                              )-._.-- (        `-----'
                             )(  l\ o ('..-.
                       _..--' _'-' '--'.-. |
                __,,-'' _,,-''            \ \
               f'. _,,-'                   \ \
              ()--  |                       \ \
                \.  |                       /  \
                  \ \                      |._  |
                   \ \                     |  ()|
                    \ \                     \  /
                     ) `-.                   | |
                    // .__)                  | |
                 _.//7'                      | |
               '---'                         j_| `
                                            (| |
                                             |  \
                                             |lllj
                                             |||||                  
";

        public const string Logo = @"
                         |  ||
                         |  ||
                         |  ||         __.--._
                     |  ||      /~~   __.-~\ _
                     |  ||  _.-~ / _---._ ~-\/~\
                     |  || // /  /~/  .-  \  /~-\
                     |  ||((( /(/_(.-(-~~~~~-)_/ |
                     |  || ) (( |_.----~~~~~-._\ /
                     |  ||    ) |              \_|
                     |  ||     (| =-_   _.-=-  |~)        ,
                     |  ||      | `~~ |   ~~'  |/~-._-'/'/_,
                     |  ||       \    |        /~-.__---~ , ,
                     |  ||       |   ~-''     || `\_~~~----~
                     |  ||_.ssSS$$\ -====-   / )\_  ~~--~
             ___.----|~~~|%$$$$$$/ \_    _.-~ /' )$s._
    __---~-~~        |   |%%$$$$/ /  ~~~~   /'  /$$$$$$$s__
  /~       ~\    ============$$/ /        /'  /$$$$$$$$$$$SS-.
/'      ./\\\\\\_( ~---._(_))$/ /       /'  /$$$$%$$$$$~      \    __      _____________.____   _________  ________      _____  ___________
(      //////////(~-(..___)/$/ /      /'  /$$%$$%$$$$'         \  /  \    /  \_   _____/|    |  \_   ___ \ \_____  \    /     \ \_   _____/
 \    |||||||||||(~-(..___)$/ /  /  /'  /$$$%$$$%$$$            | \   \/\/   /|    __)_ |    |  /    \  \/  /   |   \  /  \ /  \ |    __)_
  `-__ \\\\\\\\\\\(-.(_____) /  / /'  /$$$$%$$$$$%$             |  \        / |        \|    |__\     \____/    |    \/    Y    \|        \
      ~~""""""""""""""""""""-\.(____) /   /'  /$$$$$%%$$$$$$\_      \__/\  / /_______  /|_______ \______  /\_______  /\____|__  /_______  /
                    $|===|||  /'  /$$$$$$$%%%$$$$$( ~         ,'|         \/          \/         \/      \/         \/         \/        \/
                __  $|===|%\/'  /$$$$$$$$$$$%%%%$$|        ,''  |         _________.____       _____ _____.___._____________________
               ///\ $|===|/'  /$$$$$$%$$$$$$$%%%%$(            /'        /   _____/|    |     /  _  \\__  |   |\_   _____/\______   \
                \///\|===|  /$$$$$$$$$%%$$$$$$%%%%$\_-._       |         \_____  \ |    |    /  /_\  \/   |   | |    __)_  |       _/
                 `\//|===| /$$$$$$$$$$$%%%$$$$$$-~~~    ~      /         /        \|    |___/    |    \____   | |        \ |    |   \
                   `\|-~~(~~-`$$$$$$$$$%%%///////._       ._  |         /_______  /|_______ \____|__  / ______|/_______  / |____|_  /
                   (__--~(     ~\\\\\\\\\\\\\\\\\\\\        \ \                 \/         \/       \/\/               \/         \/
                   (__--~~(       \\\\\\\\\\\\\\\\\\|        \/
                    (__--~(       ||||||||||||||||||/       _/
                     (__.--._____//////////////////__..---~~
                     |   """"""""'''''           ___,,,,ss$$$%
                    ,%\__      __,,,\sssSS$$$$$$$$$$$$$$%%
                  ,%%%%$$$$$$$$$$\;;;;\$$$$$$$$$$$$$$$$%%%$.
                 ,%%%%%%$$$$$$$$$$%\;;;;\$$$$$$$$$$$$%%%$$$$
                ,%%%%%%%%$$$$$$$$$%$$$\;;;;\$$$$$$$$$%%$$$$$$,
               ,%%%%%%%%%$$$$$$$$%$$$$$$\;;;;\$$$$$$%%$$$$$$$$
              ,%%%%%%%%%%%$$$$$$%$$$$$$$$$\;;;;\$$$%$$$$$$$$$$$
              %%%%%%%%%%%%$$$$$$$$$$$$$$$$$$\;;;$$$$$$$$$$$$$$$
               """"==%%%%%%%$$$$$TuaXiong$$$$$$$$$$$$$$$$$$$SV""
                           $$$$$$$$$$$$$$$$$$$$====""""""""
                           """"""""""""""""""~~~~";

        //-Alex Wargacki
        public const string Devil1 = @"
                            ==(W{==========-      /===-                        
                              ||  (.--.)         /===-_---~~~~~~~~~------____  
                              | \_,|**|,__      |===-~___                _,-' `
                 -==\\        `\ ' `--'   ),    `//~\\   ~~~~`---.___.-~~      
             ______-==|        /`\_. .__/\ \    | |  \\           _-~`         
       __--~~~  ,-/-==\\      (   | .  |~~~~|   | |   `\        ,'             
    _-~       /'    |  \\     )__/==0==-\<>/   / /      \      /               
  .'        / ALEX  |   \\      /~\___/~~\/  /' /Wargacki\   /'                
 /  ____  /         |    \`\.__/-~~   \  |_/'  /          \/'                  
/-'~    ~~~~~---__  |     ~-/~         ( )   /'        _--~`                   
                  \_|      /        _) | ;  ),   __--~~                        
                    '~~--_/      _-~/- |/ \   '-~ \                            
                   {\__--_/}    / \\_>-|)<__\      \                           
                   /'   (_/  _-~  | |__>--<__|      |                          
                  |   _/) )-~     | |__>--<__|      |                          
                  / /~ ,_/       / /__>---<__/      |                          
                 o-o _//        /-~_>---<__-~      /                           
                 (^(~          /~_>---<__-      _-~                            
                ,/|           /__>--<__/     _-~                               
             ,//('(          |__>--<__|     /                  .----_          
            ( ( '))          |__>--<__|    |                 /' _---_~\        
         `-)) )) (           |__>--<__|    |               /'  /     ~\`\      
        ,/,'//( (             \__>--<__\    \            /'  //        ||      
      ,( ( ((, ))              ~-__>--<_~-_  ~--____---~' _/'/        /'       
    `~/  )` ) ,/|                 ~-_~>--<_/-__       __-~ _/                  
  ._-~//( )/ )) `                    ~~-'_/_/ /~~~~~~~__--~                    
   ;'( ')/ ,)(                              ~~~~~~~~~~                         
  ' ') '( (/                                                                   
    '   '  `
";

        public const string WelcomeText2 = @"
  __      _____________.____   _________  ________      _____  ___________ 
 /  \    /  \_   _____/|    |  \_   ___ \ \_____  \    /     \ \_   _____/ 
 \   \/\/   /|    __)_ |    |  /    \  \/  /   |   \  /  \ /  \ |    __)_  
  \        / |        \|    |__\     \____/    |    \/    Y    \|        \ 
   \__/\  / /_______  /|_______ \______  /\_______  /\____|__  /_______  / 
        \/          \/         \/      \/         \/         \/        \/  
    _________.____       _____ _____.___._____________________             
   /   _____/|    |     /  _  \\__  |   |\_   _____/\______   \            
   \_____  \ |    |    /  /_\  \/   |   | |    __)_  |       _/            
   /        \|    |___/    |    \____   | |        \ |    |   \            
  /_______  /|_______ \____|__  / ______|/_______  / |____|_  /            
          \/         \/       \/\/               \/         \/             
";

        public const string Gambit = @"

                   __    __     _                            _                                              
                  / / /\ \ \___| | ___ ___  _ __ ___   ___  | |_ ___                                        
                  \ \/  \/ / _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \                                       
                   \  /\  /  __/ | (_| (_) | | | | | |  __/ | || (_) |                                      
                    \/  \/ \___|_|\___\___/|_| |_| |_|\___|  \__\___/                                       
   __            _            _        ___                _     _ _            __   ____  _ 
   \ \  ___  ___| |_ ___ _ __( )__    / _ \__ _ _ __ ___ | |__ (_) |_    ___  / _| |___ \/ |
    \ \/ _ \/ __| __/ _ \ '__|/ __|  / /_\/ _` | '_ ` _ \| '_ \| | __|  / _ \| |_    __) | |
 /\_/ /  __/\__ \ ||  __/ |   \__ \ / /_\\ (_| | | | | | | |_) | | |_  | (_) |  _|  / __/| | 
 \___/ \___||___/\__\___|_|   |___/ \____/\__,_|_| |_| |_|_.__/|_|\__|  \___/|_|   |_____|_| 
                                                                                                
";

        // the art was made by Marcin Glinski
        public const string Castle = @"
                                 ____                                         
                              .-""    `-.      ,                               
                            .'          '.   /j\                              
                           /              \,/:/#\                /\           
                          ;              ,//' '/#\              //#\          
                          |             /' :   '/#\            /  /#\         
                          :         ,  /' /'    '/#\__..--""""""""/    /#\__      
                           \       /'\'-._:__    '/#\        ;      /#, """"""---
                            `-.   / ;#\']"" ; """"""--./#J       ':____...!       
                               `-/   /#\  J  [;[;[;Y]         |      ;        
""""""""""""---....             __.--""/    '/#\ ;   "" ""  |     !    |   #! |        
             """"--.. _.--""""     /      ,/#\'-..____.;_,   |    |   '  |        
                   ""-.        :_....___,/#} ""####"" | '_.-"",   | #['  |        
   Marcin Glinski     '-._      |[;[;[;[;|         |.;'  /;\  |      |        
                      ,   `-.   |        :     _   .;'    /;\ |   #"" |        
                      !      `._:      _  ;   ##' .;'      /;\|  _,  |        
                     .#\""""""---..._    ';, |      .;{___     /;\  ]#' |__....--
          .--.      ;'/#\         \    ]! |       ""| , """"""--./_J    /         
         /  '%;    /  '/#\         \   !' :        |!# #! #! #|    :`.__      
        i__..'%] _:_   ;##J         \      :""#...._!   '  ""  ""|__  |    `--.._
         | .--"""""" !|""""""""  |""""""----...J     | '##"""" `-._       |  """"""---.._    
     ____: |      #|      |         #|     |          ""]      ;   ___...-""T,  
    /   :  :      !|      |   _______!_    |           |__..--;""""""     ,;MM;  
   :____| :    .-.#|      |  /\      /#\   |          /'               ''MM;  
    |"""""": |   /   \|   .----+  ;      /#\  :___..--"""";                  ,'MM; 
   _Y--:  |  ;     ;.-'      ;  \______/#: /         ;                  ''MM; 
  /    |  | ;_______;     ____!  |""##""""""MM!         ;                    ,'MM;
 !_____|  |  |""#""#""|____.'""""##""  |       :         ;                     ''MM  
  | """"""""--!._|     |##""""         !       !         :____.....-------"""""""""""" |'
  |          :     |______                        ___!_ ""#""""#""""#""""""#""""""#""""""|  
__|          ;     |MM""MM""""""""""---..._______...--""""MM""MM]                   |   
  ""\-.      :      |#                                  :                   |  
    /#'.    |      /##,                                !                   |  
   .',/'\   |       #:#,                                ;       .==.       |  
  /""\'#""\',.|       ##;#,                               !     ,'||||',     |  
        /;/`:       ######,          ____             _ :     M||||||M     |  
       ###          /;""\.__""-._   """"""                   |===..M!!!!!!M_____|  
                           `--..`--.._____             _!_                    
                                          `--...____,=""_.'`-.____        
";
        public const string CastleBurning = @"
                                            ,/:/                  /\
                                          ,//' '_                //#\
                                         /' :   '/#\            /  /#\
                                        /' /'    '/#\__..--"""""""" \   /#\__
                                       '-._:__    '/#\           |   /#, """"""
                                       \']"" ; """"""--./#J          |__...!
                                  /   /#\  J  [;[;[;Y]           /    ;
                                ""/    '/#\ ;   "" ""  |     !     /  #! |
                                /      ,/#\'-..____.;_,   |    /   '  |
 Marcin Glinski                :_....___,/#} ""####"" | '_.-"",   | #['  |
                                 |[;[;[;[;|         |.;'  /;\  |      |
                                 |        :     _   .;'    /;\ |   #"" |
                               ._:      _  ;   ##' .;'      /;\|  _,  |
                         """"""---..._    ';, |      .;{___     /;\  ]#' |__...
                      _/ \    ,.   (   .]! |  )    ""| ,.""""""--.""_J    /
                     /   #\    (""   \ ) !)':    ,'  |!# #!)#!.#(`   :`'`_
                     |  ;##J .; )  ' (( ("" ):""#.;(,_!   (( ""( "";)_ ""| )"" `--
                    /   ""  |""_"".,-,._'_.,)_(..,(#."")_-._' )_') (. _..(-'.._
                   #|      |         #|     |          ""]      ;   ___...-""T
                   !|      |   ,.___(_!_..  |( ) .      .__..--"""".""     "";MM;
                .-.#|   ,. | (/\(.    /))()'|   ).')'  /"" ,)  . (`  )  '`(`M;
               /   \|   .(""--+.;)) )' ((;(,')'_((;(,));. (`(,(  '`(("" ()"";)MM""
    _Y--:  |  ;  ,. ;.(.; )  '_((,("".)'_.,;(,..,(""(()_(._;))_"") )""'_..()'..M_.
   /    |  | ;____(""_; _"".,_,._'_.,)_(..,(M. )_ ._'`)_') (. _..( '..      ,'MM
  !_____|  |  |"".;#)|_'_(('(""#)""  |;(,    :((  (  ;); ""  )""               ''MM
   | """"""""--!._| _"".,|,._'_.,)_(..,( . )_  _' )_') (.:_..(.'...-------"""""""""""" |'
   |          :     |______                        ___!_ ""#""""#""""#""""""#""""""#""""""|
 __|          ;     |MM""MM""""""""""---..._______...--""""MM""MM]                   |
   ""\-.      :      |#       ,.   (   .     ,.   (   .. :   )""       .      ""
     /#'.    |      /##,      (""     )  ),.  ("",' . )  )')  . ,'  .  '` )"" .|(
    .',/'\   |       #:#,   .; )  ' (( ("" (.; );(' (('(""() ,' ;(,.""=.)((. (`|;
   /""\'#""\',.|       ##;#,  _""., ,._'_.,.;(_""., ,._'_.,)_(..,((.')_((_'()_')|(
         /;/`:       ######,          ___""., ,._'_.,)_(..,( . )_  _' )_') (.|_
        ###          /;""\.__""-._   """"""                   |===..        _____|
                            `--..`--.._____             _!_
                                           `--...____,=""_.'`-.____
";

        public const string Mermaid = @"




                               __.---.   _______        .-------.___
                            .-'       `\/       ``\_  _/            `\
                           /      /     \ \         `\            ``\ \
                          /\.-'--/\      \ \                         \ \
                         ///       \     | |                         _\ \
                         |   __     `\   | \ _                      /  \|
                         \/   o\  __  |  \  / \                    /
                         |       `-o\ |  | /   `\                 /
                         |    \__    /   |/      `\             /'
                 _______-'\ `-.___  /|   ||        `\_         \
              .-'        / \ `--' /' | | |\\          `\        `\
       ------/              `---'/   | ||  `\-----------\         `\-----------------
            /             `         | |      \           `\          \
            |              `        || |      \            `\         `\
            |                       | |        \--.__        `\         `\
           .'     /\                ||   \      `    `--._     \          `\
           |     .' \               |     \      \        `--.__\      \    `\
           |     |  .                      \     `              `--._.-'       \
          .'    .'  |                 |     \     \                             \
          |     |   |        .        /      \     \            __               |
          |    .'    \      .__\_____/_______ \     \_________./  ``------.______/
         |_____|_-----u----'                 `-:F_P:_\           ``____
                     -  -    --___           __       _-                 -- -
          ---  -- -   -----       ---_-       __-       -            - --    ---\---
            --    --     ---           --__      -_--    ---             -          -
              ----  --     ---    -        -__       --__-- --
                ---   -       ---  ---- -                 -_- ---
                  -    -         -    ---                    ---
                   -                   ---                       --
                                         --
";
        //credits to jgs  for the  chest art
        public const string Chest = @"
       ____...------------...____
  _.-""` /o/__ ____ __ __  __ \o\_`""-._
.'     / /                    \ \     '.
|=====/o/======================\o\=====|
|____/_/________..____..________\_\____|
/   _/ \_     <_o#\__/#o_>     _/ \_   \
\_________\####/__jgs___\####/_________/
 |===\!/========================\!/===|
 |   |=|          .---.         |=|   |
 |===|o|=========/     \========|o|===|
 |   | |         \() ()/        | |   |
 |===|o|======{'-.) A (.-'}=====|o|===|
 | __/ \__     '-.\uuu/.-'    __/ \__ |
 |==== .'.'^'.'.====|===.'.'^'.'. ====|
 |  _\o/   __  {.' __  '.} _   _\o/  _|
 `""""""""-""""""""""""""""""""""""""""""""""""""""""""""""""""-""""""""`
";


        //art made by LGB
        public const string OldManHouseEnding = @"
                                                     ___
                                             ___..--'  .`.
                                    ___...--'     -  .` `.`.
                           ___...--' _      -  _   .` -   `.`.
                  ___...--'  -       _   -       .`  `. - _ `.`.
           __..--'_______________ -         _  .`  _   `.   - `.`.
        .`    _ /\    -        .`      _     .`__________`. _  -`.`.
      .` -   _ /  \_     -   .`  _         .` |    LGB    |`.   - `.`.
    .`-    _  /   /\   -   .`        _   .`   |___________|  `. _   `.`.
  .`________ /__ /_ \____.`____________.`     ___       ___  - `._____`|
    |   -  __  -|    | - |  ____  |   | | _  |   |  _  |   |  _ |
    | _   |  |  | -  |   | |.--.| |___| |    |___|     |___|    |
    |     |--|  |    | _ | |'--'| |---| |   _|---|     |---|_   |
    |   - |__| _|  - |   | |.--.| |   | |    |   |_  _ |   |    |
 ---``--._      |    |   |=|'--'|=|___|=|====|___|=====|___|====|
 -- . ''  ``--._| _  |  -|_|.--.|_______|_______________________|
`--._           '--- |_  |:|'--'|:::::::|:::::::::::::::::::::::|
_____`--._ ''      . '---'``--._|:::::::|:::::::::::::::::::::::|
----------`--._          ''      ``--.._|:::::::::::::::::::::::|
`--._ _________`--._'        --     .   ''-----.................'
     `--._----------`--._.  _           -- . :''           -    ''
          `--._ _________`--._ :'              -- . :''      -- . ''
 -- . ''       `--._ ---------`--._   -- . :''
          :'        `--._ _________`--._:'  -- . ''      -- . ''
  -- . ''     -- . ''    `--._----------`--._      -- . ''     -- . ''
                              `--._ _________`--._
 -- . ''           :'              `--._ ---------`--._-- . ''    -- . ''
          -- . ''       -- . ''         `--._ _________`--._   -- . ''
:'                 -- . ''          -- . ''  `--._----------`--._
";

        //art by NA
        public const string OldGuyTransformed = @"
                             .-,
                ,---._   _  -' >
               | ""\ \\\ //_=33'
               7-_ || \//-' //
               |""= / -'/'' |/
           __-'_   -'-/__  ||
          / ,--'     / ,-'-||
         /  /  ___ //    ,-||_
        /  _--/_  '-    / \|_';
       |  /  // ""\\\   /     ""
       / /  //        |   , -'
      /  ;,//,        /  /,  \
     |   |_/  |      /  / /  |
     '-\/\_,_,/ _   V  /\,7-""'
        '    /   ''---'  |
             |      \\   |
             |       \\  |
             |       |\\ /
             | \     /|\|
             |  |    || ;
             | NA   /|| ;
             |  | ,/ / /
             |  \ / \/ |
            /    | \_//
            |    | """" /
           ,'   ,'  |,'
           /      \| |
          /     /  \ |
         /     /   / \
        /     /   / ,/
       //  /       /\\
    _-'/        ,-' | )
 ,-'       \_   \   \ |
/__,--      _,-""""  /   \
    \____,-'       '---'
";
    }
}