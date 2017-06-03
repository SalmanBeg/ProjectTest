using HRSystem.Services.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRSystem.Web.Common
{
    public class MakeApiObject
    {
        public JObject MakeMessageCreateObject(MessageCreateDto objMessageCreate)
        {
            var MsgCreate = new
            {
                message = new
                {
                    objMessageCreate.source_guid,
                    objMessageCreate.text
                }
            };
            return JObject.FromObject(MsgCreate);
        }

        public JObject MakeAddMembersInGroup(AddMembersInGroupDto objAddMembersInGroup)
        {
            var MsgAddMembersInGroup = new JObject(new JProperty("members", new JArray(
                new JObject(
                   new JProperty("nickname", objAddMembersInGroup.nickname),
                   new JProperty("user_id", objAddMembersInGroup.email),
                   new JProperty("guid", objAddMembersInGroup.guid),
                   new JProperty("phone_number", objAddMembersInGroup.phone_number),
                   new JProperty("email", objAddMembersInGroup.email)
                ))));
            return MsgAddMembersInGroup;
        }

        public JObject MakeUpdateNickName(UpdateMembershipNickNameDto objUpdateMembershipNickName)
        {
            var MsgUpdateNickName = new
            {
                membership = new
                {
                    objUpdateMembershipNickName.nickname
                }
            };
            return JObject.FromObject(MsgUpdateNickName);
        }

        public JObject MakeNewGroup(CreateNewGroupDto objCreateNewGroup)
        {
            var CreateGroup = new
            {
                objCreateNewGroup.name,
                objCreateNewGroup.description,
                objCreateNewGroup.share
            };
            return JObject.FromObject(CreateGroup);
        }

        public JObject MakeUpdateGroup(UpdateGroupDto objUpdateGroup)
        {
            var UpdateGroup = new
            {
                objUpdateGroup.name,
                objUpdateGroup.share,
                objUpdateGroup.office_mode,
                objUpdateGroup.description
            };
            return JObject.FromObject(UpdateGroup);
        }

        public JObject MakeReJoinGroup(ReJoinGroupDto objReJoinGroup)
        {
            var ReJoinGroup = new
            {
                objReJoinGroup.group_id
            };
            return JObject.FromObject(ReJoinGroup);
        }

        public JObject MakeChangeOwners(ChangeOwnersDto objChangeOwners)
        {
            var msgChangeOwners = new JObject(new JProperty("requests", new JArray(
                    new JObject(
                        new JProperty("group_id", objChangeOwners.group_id),
                        new JProperty("owner_id", objChangeOwners.owner_id)
                ))));
            return msgChangeOwners;
        }

        public JObject MakeRemoveMember(RemoveMemberDto objRemoveMember)
        {
            var msgRemoveMember = new
            {
                objRemoveMember.membership_id
            };
            return JObject.FromObject(msgRemoveMember);
        }

        public JObject MakeUpdateUser(UpdateUserDto objUpdateUser)
        {
            var msgUpdateUser = new
            {
                objUpdateUser.name,
                objUpdateUser.email,
                objUpdateUser.zip_code
            };
            return JObject.FromObject(msgUpdateUser);
        }

        public JObject MakeCreateDirectMessageToUser(CreateDirectMessageDto objCreateDirectMessage)
        {
            var msgCreateDirectMessage = new
            {
                direct_message = new
                {
                    objCreateDirectMessage.source_guid,
                    objCreateDirectMessage.recipient_id,
                    objCreateDirectMessage.text
                }
            };
            return JObject.FromObject(msgCreateDirectMessage);
        }
    }
}