//Copyright(c) 2023, Valery
//All rights reserved.
//This source code is licensed under the GNU GENERAL PUBLIC LICENSE found in the
//LICENSE file in the root directory of this source tree. 

using System;
namespace Valery_s_Dungeon.Combat
{
    public class Message
    {
        public List<MessagePart> parts = new List<MessagePart>();

        public void Render()
        {
            parts.ForEach(p => p.Render());
        }

        public class MessagePart
        {

            public string text;
            public ConsoleColor color;

            public MessagePart(string text, ConsoleColor color)
            {
                this.text = text;
                this.color = color;
            }

            public void Render()
            {
                Console.ForegroundColor = color;
                Console.Write(text);
            }
        }
    }
}

