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

        public async Task Render()
        {
            foreach (var part in parts)
            {
				await part.Render();
			}
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

            public async Task Render()
            {
                BlazorConsole.ForegroundColor = color;
                await BlazorConsole.Write(text);
            }
        }
    }
}

