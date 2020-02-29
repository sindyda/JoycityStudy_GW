using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//느리기는 하지만 편하다고는 생각합니다.
namespace ObserverDelegateVersion
{

    public struct NotiIcon
    {
        public int NewNormalMail;
        public int NewSystemMail;
        public int NewGuildMail;
        public override string ToString()
        {
            return $"{NewNormalMail},{NewSystemMail},{NewGuildMail}";
        }
    }

    public enum MailType
    {
        NormalMail,
        SystemMail,
        GuildMail,
    }

    public struct MailItem
    {
        string title;
        string content;
    }



    public delegate void OnNotify(in NotiIcon noti);

    public class MailItemDlg
    {
        OnNotify notify;

        public void AddObserver(OnNotify noti)
        {
            notify += noti;
        }

        public void RemoveObserver(OnNotify noti)
        {
            notify -= noti;
        }

        NotiIcon notivalue;
        public MailItemDlg()
        {
            notivalue = new NotiIcon()
            {
                NewGuildMail = 0,
                NewNormalMail = 0,
                NewSystemMail = 0,
            };
        }

        public void ReadItem()
        {
            notivalue.NewSystemMail = 0;
            notivalue.NewNormalMail = 0;
            notivalue.NewGuildMail = 0;

            notify(notivalue);
        }

        public void NewItem(MailType type,MailItem item)
        {
            switch (type)
            {
                case MailType.GuildMail:
                    notivalue.NewGuildMail++;
                    break;
                case MailType.NormalMail:
                    notivalue.NewNormalMail++;
                    break;
                case MailType.SystemMail:
                    notivalue.NewSystemMail++;
                    break;
            }

            notify(notivalue);
        }

    }

    

    public class ObserverDelegate : MonoBehaviour
    {
        void Start()
        {
            MailItemDlg dlg = new MailItemDlg();
            dlg.AddObserver(OnUpdate);
            //단점이 있다면 구분이 잘 안된다는 겁니다.
            //관리가 잘못되면 큰일난다는 단점이 있스비다.
            dlg.AddObserver(OnUpdate);

            dlg.NewItem(MailType.GuildMail, new MailItem());
            dlg.NewItem(MailType.NormalMail, new MailItem());
            dlg.NewItem(MailType.GuildMail, new MailItem());
            dlg.NewItem(MailType.SystemMail, new MailItem());
            dlg.NewItem(MailType.GuildMail, new MailItem());

            dlg.ReadItem();

            dlg.NewItem(MailType.SystemMail, new MailItem());
            dlg.NewItem(MailType.GuildMail, new MailItem());
            dlg.NewItem(MailType.NormalMail, new MailItem());

            dlg.RemoveObserver(OnUpdate);
            dlg.RemoveObserver(OnUpdate);
        }


        void OnUpdate(in NotiIcon icon)
        {
            Debug.Log(icon.ToString());
        }
    }

}


